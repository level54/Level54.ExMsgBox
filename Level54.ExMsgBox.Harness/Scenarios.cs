using System;
using System.IO;
using System.Windows.Forms;
using Level54.ExMsgBox;

namespace Level54.ExMsgBox.Harness;

internal static class Scenarios
{
    public static int RunSimple()
    {
        var ex = new InvalidOperationException("Simple harness exception") { Source = "Harness" };
        var box = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error)
        {
            ShowToolBar = true,
            Beep = false,
        };
        return ExitFromDialogResult(box.Show(null));
    }

    public static int RunNested()
    {
        var leaf = new InvalidOperationException("Leaf cause");
        var mid = new InvalidOperationException("Mid cause", leaf);
        var top = new Exception("Top-level failure", mid) { Source = "Harness" };

        var box = new ExceptionMessageBox(top, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error)
        {
            ShowToolBar = true,
            Beep = false,
        };
        return ExitFromDialogResult(box.Show(null));
    }

    public static int RunSql()
    {
        var ex = new global::Microsoft.Data.SqlClient.SqlException("Login failed for user 'demo'")
        {
            Source = "Harness",
            Number = 18456,
            Class = 14,
            State = 1,
            LineNumber = 1,
            Procedure = "sp_Login",
            Server = "DEMO-SQL-01",
        };

        var box = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error)
        {
            ShowToolBar = true,
            Beep = false,
        };
        return ExitFromDialogResult(box.Show(null));
    }

    public static int RunCheckBox(bool preChecked)
    {
        var ex = new InvalidOperationException("Checkbox scenario") { Source = "Harness" };
        var box = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Warning)
        {
            ShowToolBar = false,
            Beep = false,
            ShowCheckBox = true,
            CheckBoxText = "Don't show this again",
            IsCheckBoxChecked = preChecked,
        };
        box.Show(null);
        // Exit code mirrors the checkbox state so UI tests can assert.
        return box.IsCheckBoxChecked ? 0 : 1;
    }

    public static int RunCopyIntercept()
    {
        var ex = new InvalidOperationException("Intercept scenario") { Source = "Harness" };
        var box = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Information)
        {
            ShowToolBar = true,
            Beep = false,
        };

        var capturePath = Environment.GetEnvironmentVariable("EXMSGBOX_HARNESS_COPY_CAPTURE");

        box.OnCopyToClipboard += (_, args) =>
        {
            if (!string.IsNullOrEmpty(capturePath))
            {
                try { File.WriteAllText(capturePath, args.ClipboardText); }
                catch { /* best effort */ }
            }
            args.EventHandled = true; // suppress the library's own clipboard write
        };

        return ExitFromDialogResult(box.Show(null));
    }

    private static int ExitFromDialogResult(DialogResult dr) => dr switch
    {
        DialogResult.OK => 0,
        DialogResult.Cancel => 1,
        DialogResult.Yes => 2,
        DialogResult.No => 3,
        DialogResult.Abort => 4,
        DialogResult.Retry => 5,
        DialogResult.Ignore => 6,
        _ => 10,
    };
}

