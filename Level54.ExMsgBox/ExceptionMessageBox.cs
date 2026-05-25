using System;
using System.ComponentModel;
using System.Windows.Forms;
using Level54.ExMsgBox.Internal;

namespace Level54.ExMsgBox;

public class ExceptionMessageBox
{
    public ExceptionMessageBox() { }

    public ExceptionMessageBox(Exception exception)
    {
        Message = exception;
    }

    public ExceptionMessageBox(string text)
    {
        Text = text ?? string.Empty;
    }

    public ExceptionMessageBox(string text, string caption)
    {
        Text = text ?? string.Empty;
        Caption = caption ?? string.Empty;
    }

    public ExceptionMessageBox(Exception exception, ExceptionMessageBoxButtons buttons)
    {
        Message = exception;
        Buttons = buttons;
    }

    public ExceptionMessageBox(Exception exception, ExceptionMessageBoxButtons buttons, ExceptionMessageBoxSymbol symbol)
    {
        Message = exception;
        Buttons = buttons;
        Symbol = symbol;
    }

    public ExceptionMessageBox(
        Exception exception,
        ExceptionMessageBoxButtons buttons,
        ExceptionMessageBoxSymbol symbol,
        ExceptionMessageBoxDefaultButton defaultButton)
    {
        Message = exception;
        Buttons = buttons;
        Symbol = symbol;
        DefaultButton = defaultButton;
    }

    public Exception? Message { get; set; }
    public string Caption { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public ExceptionMessageBoxButtons Buttons { get; set; }
    public ExceptionMessageBoxSymbol Symbol { get; set; } = ExceptionMessageBoxSymbol.Warning;
    public ExceptionMessageBoxDefaultButton DefaultButton { get; set; }
    public bool ShowToolBar { get; set; } = true;
    public bool Beep { get; set; } = true;
    public bool ShowCheckBox { get; set; }
    public string CheckBoxText { get; set; } = string.Empty;
    public bool IsCheckBoxChecked { get; set; }

    public event CopyToClipboardEventHandler? OnCopyToClipboard;

    public DialogResult Show(IWin32Window? owner)
    {
        ValidateForShow();

        var displayException = Message ?? new ApplicationException(Text);
        var caption = ResolveCaption(owner, displayException);

        using var form = new ExceptionMessageBoxForm(this, displayException, caption);

        if (owner is null)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowInTaskbar = true;
        }
        else
        {
            form.StartPosition = FormStartPosition.CenterParent;
        }

        form.Shown += (_, _) => CenterOnScreenIfNeeded(form, owner);

        form.IsCheckBoxChecked = IsCheckBoxChecked;
        var result = form.ShowDialog(owner);
        IsCheckBoxChecked = form.IsCheckBoxChecked;

        return result;
    }

    public static DialogResult Show(Exception exception) =>
        new ExceptionMessageBox(exception).Show(null);

    public static DialogResult Show(IWin32Window? owner, Exception exception) =>
        new ExceptionMessageBox(exception).Show(owner);

    public static string GetMessageText(Exception exception) =>
        MessageTextBuilder.BuildDetailsText(exception, caption: string.Empty);

    /// <summary>Internal seam: fires OnCopyToClipboard. Returns true if a handler set EventHandled=true.</summary>
    internal bool RaiseCopyToClipboard(string clipboardText)
    {
        var handler = OnCopyToClipboard;
        if (handler is null) return false;

        var args = new CopyToClipboardEventArgs(clipboardText);
        handler(this, args);
        return args.EventHandled;
    }

    private static void CenterOnScreenIfNeeded(Form form, IWin32Window? owner)
    {
        // The chosen StartPosition isn't always respected when the form is shown from a
        // non-Form owner. Re-centre on the relevant screen as a safety net.
        var screen = owner is Control c ? Screen.FromControl(c) : Screen.FromPoint(Cursor.Position);
        var area = screen.WorkingArea;
        var location = new System.Drawing.Point(
            area.Left + Math.Max(0, (area.Width - form.Width) / 2),
            area.Top + Math.Max(0, (area.Height - form.Height) / 2));
        if (form.Location != location)
        {
            form.Location = location;
        }
    }

    private string ResolveCaption(IWin32Window? owner, Exception displayException)
    {
        if (!string.IsNullOrEmpty(Caption)) return Caption;
        if (!string.IsNullOrEmpty(displayException.Source)) return displayException.Source!;
        if (owner is Form ownerForm && !string.IsNullOrEmpty(ownerForm.Text)) return ownerForm.Text;
        return "Error";
    }

    /// <summary>Internal seam: runs parameter validation without opening a dialog.</summary>
    internal void ValidateForShow()
    {
        if (Message is null && string.IsNullOrEmpty(Text))
            throw new ArgumentNullException(nameof(Message));

        if (!Enum.IsDefined(typeof(ExceptionMessageBoxButtons), Buttons))
            throw new InvalidEnumArgumentException(nameof(Buttons), (int)Buttons, typeof(ExceptionMessageBoxButtons));

        if (Buttons == ExceptionMessageBoxButtons.Custom)
            throw new NotSupportedException(
                "ExceptionMessageBoxButtons.Custom is not supported in this implementation.");

        if (!Enum.IsDefined(typeof(ExceptionMessageBoxSymbol), Symbol))
            throw new InvalidEnumArgumentException(nameof(Symbol), (int)Symbol, typeof(ExceptionMessageBoxSymbol));

        if (!Enum.IsDefined(typeof(ExceptionMessageBoxDefaultButton), DefaultButton))
            throw new InvalidEnumArgumentException(
                nameof(DefaultButton),
                (int)DefaultButton,
                typeof(ExceptionMessageBoxDefaultButton));

        var buttonCount = ButtonCountFor(Buttons);
        if ((int)DefaultButton >= buttonCount)
            throw new InvalidEnumArgumentException(
                nameof(DefaultButton),
                (int)DefaultButton,
                typeof(ExceptionMessageBoxDefaultButton));
    }

    internal static int ButtonCountFor(ExceptionMessageBoxButtons buttons) => buttons switch
    {
        ExceptionMessageBoxButtons.OK => 1,
        ExceptionMessageBoxButtons.OKCancel => 2,
        ExceptionMessageBoxButtons.YesNo => 2,
        ExceptionMessageBoxButtons.RetryCancel => 2,
        ExceptionMessageBoxButtons.YesNoCancel => 3,
        ExceptionMessageBoxButtons.AbortRetryIgnore => 3,
        _ => 0,
    };
}
