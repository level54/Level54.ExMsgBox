using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Level54.ExMsgBox.Internal;

internal sealed partial class ExceptionMessageBoxForm : Form
{
    private const int FixedClientWidth = 640;
    private const int InnerExceptionIndentStepPx = 20;
    private const int MaxMessageWidth = 550;

    private readonly ExceptionMessageBox _owner;
    private readonly Exception _displayException;
    private readonly string _caption;
    private Button[] _generalButtons = Array.Empty<Button>();

    public ExceptionMessageBoxForm(ExceptionMessageBox owner, Exception displayException, string caption)
    {
        _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        _displayException = displayException ?? throw new ArgumentNullException(nameof(displayException));
        _caption = caption ?? string.Empty;

        InitializeComponent();

        _generalButtons = new[] { btn1, btn2, btn3, btn4, btn5 };

        Load += OnLoadInitialise;
        FormClosing += OnFormClosing;
        btnCopy.Click += (_, _) => CopyToClipboard();
        btnDetails.Click += (_, _) => ShowDetails();
        btnHelp.Click += (_, _) =>
        {
            if (_displayException.HelpLink is not null)
            {
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(_displayException.HelpLink) { UseShellExecute = true }); }
                catch { MessageBox.Show("Failed to open help link.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        };
        chkDontShow.CheckedChanged += (_, _) => _owner.IsCheckBoxChecked = chkDontShow.Checked;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCheckBoxChecked
    {
        get => chkDontShow.Checked;
        set => chkDontShow.Checked = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ExceptionMessageBoxDialogResult CustomDialogResult { get; private set; } = ExceptionMessageBoxDialogResult.None;

    // ---------- on Load ----------

    private void OnLoadInitialise(object? sender, EventArgs e)
    {
        Text = string.IsNullOrEmpty(_caption) ? "Error" : _caption;

        ConfigureIcon();
        ConfigurePrimaryMessage();
        ConfigureInnerExceptions();
        ConfigureCheckBox();
        ConfigureActions();
        ConfigureButtons();
        ApplyControlBoxRule();

        // AutoSize cascade: trigger layout from innermost (where we added labels)
        // outwards so the Form's AutoSize=true grows correctly.
        messageStack.PerformLayout();
        pnlBody.PerformLayout();
        rootLayout.PerformLayout();
        PerformLayout();

        if (_owner.Beep) PlayBeep();

        var defIdx = (int)_owner.DefaultButton;
        if (defIdx < 0 || defIdx >= _generalButtons.Length) defIdx = 0;
        var defaultBtn = FirstVisibleAt(defIdx);
        defaultBtn?.Focus();
    }

    private Button? FirstVisibleAt(int targetIndex)
    {
        int seen = 0;
        foreach (var b in _generalButtons)
        {
            if (!b.Visible) continue;
            if (seen == targetIndex) return b;
            seen++;
        }
        return null;
    }

    // ---------- configuration steps ----------

    private void ConfigureIcon()
    {
        var icon = SymbolMapper.ResolveIcon(_owner.Symbol);
        if (icon is null)
        {
            pnlIcon.Visible = false;
            pnlBody.ColumnStyles[0].Width = 0; // collapse icon column
        }
        else
        {
            pnlIcon.Image = icon.ToBitmap();
            pnlIcon.Visible = true;
        }
    }

    private void ConfigurePrimaryMessage()
    {
        lblPrimaryMessage.Text = MessageTextBuilder.BuildPrimaryText(_displayException, _caption);
    }

    private void ConfigureInnerExceptions()
    {
        // Remove any previously-added inner labels (in case the form is reused).
        // We add labels DIRECTLY to messageStack rather than the designer-supplied
        // flpInnerExceptions FlowLayoutPanel — a FlowLayoutPanel nested inside another
        // FlowLayoutPanel doesn't report its preferred height reliably, which clips the
        // bottom rows of the dialog.
        var stale = new List<Control>();
        foreach (Control c in messageStack.Controls)
        {
            if (c is Label lbl && lbl.Name.StartsWith("lblInner", StringComparison.Ordinal))
                stale.Add(c);
        }
        foreach (var c in stale) messageStack.Controls.Remove(c);

        // The unused designer container stays hidden.
        flpInnerExceptions.Visible = false;
        if (flpInnerExceptions.Controls.Count > 0) flpInnerExceptions.Controls.Clear();

        messageStack.SuspendLayout();

        var depth = 0;
        Control? insertAfter = lblAdditionalInfoHeader;
        for (Exception? inner = _displayException.InnerException; inner is not null; inner = inner.InnerException)
        {
            depth++;
            var label = new Label
            {
                Name = "lblInner" + depth.ToString(System.Globalization.CultureInfo.InvariantCulture),
                AutoSize = true,
                Text = "↳ " + MessageTextBuilder.BuildPrimaryText(inner, _caption),
                MaximumSize = new Size(Math.Max(160, MaxMessageWidth - InnerExceptionIndentStepPx * depth), 0),
                Margin = new Padding(InnerExceptionIndentStepPx * depth, 0, 0, 4),
            };
            messageStack.Controls.Add(label);
            // FlowLayoutPanel orders children by Controls collection insertion order; we
            // want the new labels to come right after lblAdditionalInfoHeader and before
            // chkDontShow. SetChildIndex repositions accordingly.
            var targetIdx = messageStack.Controls.GetChildIndex(insertAfter) + 1;
            messageStack.Controls.SetChildIndex(label, targetIdx);
            insertAfter = label;
        }

        var hasInner = depth > 0;
        lblAdditionalInfoHeader.Visible = hasInner;

        messageStack.ResumeLayout(true);
    }

    private void ConfigureCheckBox()
    {
        chkDontShow.Visible = _owner.ShowCheckBox;
        if (!_owner.ShowCheckBox) return;

        chkDontShow.Text = string.IsNullOrEmpty(_owner.CheckBoxText)
            ? "Don't show this message again"
            : _owner.CheckBoxText;
        chkDontShow.Checked = _owner.IsCheckBoxChecked;
    }

    private void ConfigureActions()
    {
        btnCopy.Visible = _owner.ShowToolBar;
        btnDetails.Visible = _owner.ShowToolBar && MessageTextBuilder.HasTechnicalDetails(_displayException);
        btnHelp.Visible = _displayException.HelpLink != null;
    }

    private void ConfigureButtons()
    {
        var (labels, results) = ButtonsForCurrentSet(_owner.Buttons);

        for (int i = 0; i < _generalButtons.Length; i++)
        {
            var btn = _generalButtons[i];
            if (i < labels.Count)
            {
                btn.Text = labels[i];
                btn.DialogResult = results[i];
                btn.Visible = true;
            }
            else
            {
                btn.Visible = false;
                btn.DialogResult = DialogResult.None;
            }
        }

        var defIdx = (int)_owner.DefaultButton;
        if (defIdx < 0 || defIdx >= labels.Count)
        {
            throw new InvalidEnumArgumentException(
                nameof(_owner.DefaultButton), (int)_owner.DefaultButton, typeof(ExceptionMessageBoxDefaultButton));
        }
        AcceptButton = _generalButtons[defIdx];

        Button? cancel = null;
        for (int i = 0; i < labels.Count; i++)
        {
            if (results[i] == DialogResult.Cancel) { cancel = _generalButtons[i]; break; }
        }
        if (cancel is null)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                if (results[i] == DialogResult.No) { cancel = _generalButtons[i]; break; }
            }
        }
        CancelButton = cancel;
    }

    private void ApplyControlBoxRule()
    {
        // Match MS: YesNo and AbortRetryIgnore hide the close box so the user must pick a button.
        ControlBox = _owner.Buttons is not (
            ExceptionMessageBoxButtons.YesNo or
            ExceptionMessageBoxButtons.AbortRetryIgnore);
    }

    // ---------- runtime events ----------

    private void OnFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (_owner.Buttons is ExceptionMessageBoxButtons.YesNo or ExceptionMessageBoxButtons.AbortRetryIgnore)
        {
            if (DialogResult == DialogResult.None)
            {
                e.Cancel = true;
                NativeMethods.MessageBeep(NativeMethods.MB_ICONHAND);
            }
        }
        else if (_owner.Buttons == ExceptionMessageBoxButtons.OK && DialogResult == DialogResult.None)
        {
            DialogResult = DialogResult.OK;
        }
    }

    private void PlayBeep()
    {
        var type = _owner.Symbol switch
        {
            ExceptionMessageBoxSymbol.Error or
            ExceptionMessageBoxSymbol.Hand => NativeMethods.MB_ICONHAND,
            ExceptionMessageBoxSymbol.Information or
            ExceptionMessageBoxSymbol.Asterisk => NativeMethods.MB_ICONEXCLAMATION,
            _ => NativeMethods.MB_ICONASTERISK,
        };
        NativeMethods.MessageBeep(type);
    }

    private void CopyToClipboard()
    {
        var labels = new List<string>();
        foreach (var b in _generalButtons)
        {
            if (b.Visible) labels.Add(b.Text);
        }

        var text = MessageTextBuilder.BuildClipboardText(_displayException, _caption, labels);
        if (_owner.RaiseCopyToClipboard(text)) return;

        try { Clipboard.SetText(text); }
        catch { /* clipboard contention; best effort */ }
    }

    private void ShowDetails()
    {
        using var dlg = new AdvancedInformationForm(_displayException, _caption);
        dlg.ShowDialog(this);
    }

    // ---------- button-set helpers ----------

    private static (IReadOnlyList<string> Labels, IReadOnlyList<DialogResult> Results) ButtonsForCurrentSet(
        ExceptionMessageBoxButtons buttons) => buttons switch
    {
        ExceptionMessageBoxButtons.OK =>
            (new[] { "OK" }, new[] { DialogResult.OK }),
        ExceptionMessageBoxButtons.OKCancel =>
            (new[] { "OK", "Cancel" }, new[] { DialogResult.OK, DialogResult.Cancel }),
        ExceptionMessageBoxButtons.YesNo =>
            (new[] { "Yes", "No" }, new[] { DialogResult.Yes, DialogResult.No }),
        ExceptionMessageBoxButtons.YesNoCancel =>
            (new[] { "Yes", "No", "Cancel" }, new[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel }),
        ExceptionMessageBoxButtons.AbortRetryIgnore =>
            (new[] { "Abort", "Retry", "Ignore" }, new[] { DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore }),
        ExceptionMessageBoxButtons.RetryCancel =>
            (new[] { "Retry", "Cancel" }, new[] { DialogResult.Retry, DialogResult.Cancel }),
        _ => (Array.Empty<string>(), Array.Empty<DialogResult>()),
    };
}
