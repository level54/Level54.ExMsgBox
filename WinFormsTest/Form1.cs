using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Level54.ExMsgBox;

namespace WinFormsTest;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    // ---------- Core states ----------

    private void btnSimple_Click(object sender, EventArgs e)
    {
        Show(new Exception("This is a simple test exception."));
    }

    private void btnThrown_Click(object sender, EventArgs e)
    {
        try
        {
            ThrowDeep();
        }
        catch (Exception ex)
        {
            Show(ex);
        }
    }

    private static void ThrowDeep()
    {
        throw new InvalidOperationException(
            "Operation failed because the workflow is in an invalid state.");
    }

    private void btnNested2_Click(object sender, EventArgs e)
    {
        var inner = new InvalidOperationException("The underlying connection was closed unexpectedly.");
        var outer = new ApplicationException("Failed to load customer record.", inner);
        Show(outer);
    }

    private void btnNested3_Click(object sender, EventArgs e)
    {
        var leaf = new TimeoutException("Network request did not complete within 30 seconds.");
        var mid  = new InvalidOperationException("Authentication failed.", leaf);
        var top  = new ApplicationException("Failed to load dashboard.", mid);
        Show(top);
    }

    private void btnSql_Click(object sender, EventArgs e)
    {
        var sql = new Microsoft.Data.SqlClient.SqlException("Cannot insert duplicate key row in object 'dbo.Customers' with unique index 'IX_Customers_Email'.")
        {
            Number = 2601,
            Class = 14,
            State = 1,
            LineNumber = 12,
            Procedure = "usp_InsertCustomer",
            Server = "PROD-SQL-01\\SQLEXPRESS",
            Source = ".NET SqlClient Data Provider",
        };
        Show(sql);
    }

    private void btnSqlInner_Click(object sender, EventArgs e)
    {
        var sql = new Microsoft.Data.SqlClient.SqlException("Login failed for user 'app_user'.")
        {
            Number = 18456,
            Class = 14,
            State = 1,
            LineNumber = 1,
            Server = "PROD-SQL-01",
            Source = ".NET SqlClient Data Provider",
        };
        var outer = new ApplicationException("Failed to open database connection.", sql);

        try
        {
            throw outer;
        }
        catch (Exception)
        {
            Show(outer);
        }

    }

    private void btnAdvanced_Click(object sender, EventArgs e)
    {
        var ex = new InvalidOperationException("Customer record validation failed.");
        ex.Data["AdvancedInformation.CustomerId"] = "C-12345";
        ex.Data["AdvancedInformation.Operation"] = "Update";
        ex.Data["AdvancedInformation.Field"]    = "EmailAddress";
        ex.Data["AdvancedInformation.Reason"]   = "Format invalid";
        Show(ex);
    }

    private void btnLong_Click(object sender, EventArgs e)
    {
        var message = string.Join(" ", new List<string>(new[]
        {
            "The application encountered a long-form error condition that requires the dialog",
            "to wrap text gracefully across multiple lines.",
            "The operation 'Synchronise Customer Records' failed at step 7 of 12 because the",
            "remote endpoint at https://api.example.com/v3/customers/sync rejected the request",
            "with status 422 Unprocessable Entity and a body indicating that 4 of the 1,287",
            "records in the batch could not be reconciled with the master schema.",
        }));
        Show(new InvalidOperationException(message));
    }

    // ---------- Button sets ----------

    private void btnBtnsOk_Click(object sender, EventArgs e)              => Show(SampleException(), ExceptionMessageBoxButtons.OK);
    private void btnBtnsOkCancel_Click(object sender, EventArgs e)        => Show(SampleException(), ExceptionMessageBoxButtons.OKCancel);
    private void btnBtnsYesNo_Click(object sender, EventArgs e)           => Show(ConfirmException(), ExceptionMessageBoxButtons.YesNo, ExceptionMessageBoxSymbol.Question);
    private void btnBtnsYesNoCancel_Click(object sender, EventArgs e)     => Show(ConfirmException(), ExceptionMessageBoxButtons.YesNoCancel, ExceptionMessageBoxSymbol.Question);
    private void btnBtnsRetryCancel_Click(object sender, EventArgs e)     => Show(SampleException(), ExceptionMessageBoxButtons.RetryCancel);
    private void btnBtnsAbortRetryIgnore_Click(object sender, EventArgs e)=> Show(SampleException(), ExceptionMessageBoxButtons.AbortRetryIgnore);

    // ---------- Symbols ----------

    private void btnSymError_Click(object sender, EventArgs e)       => Show(SampleException(), ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error);
    private void btnSymWarning_Click(object sender, EventArgs e)     => Show(SampleException(), ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Warning);
    private void btnSymInformation_Click(object sender, EventArgs e) => Show(SampleException(), ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Information);
    private void btnSymQuestion_Click(object sender, EventArgs e)    => Show(ConfirmException(), ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Question);

    // ---------- Optional features ----------

    private void btnCheckBox_Click(object sender, EventArgs e)
    {
        var box = new ExceptionMessageBox(SampleException(), ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Warning)
        {
            ShowToolBar = true,
            ShowCheckBox = true,
            CheckBoxText = "Don't show this message again",
        };
        box.Show(this);
        MessageBox.Show(this, "Checkbox state: " + box.IsCheckBoxChecked, "Result");
    }

    private void btnHelpLink_Click(object sender, EventArgs e)
    {
        // HelpLink is out of scope for the native library; included so the button still
        // exists and parity with WinFormsTest472 is preserved. The dialog won't show a Help link.
        var ex = new InvalidOperationException("Required configuration value is missing.")
        {
            HelpLink = "https://learn.microsoft.com/dotnet/standard/exceptions/",
        };
        Show(ex);
    }

    private void btnNoToolbar_Click(object sender, EventArgs e)
    {
        var box = new ExceptionMessageBox(SampleException(), ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Warning)
        {
            ShowToolBar = false,
        };
        box.Show(this);
    }

    // ---------- helpers ----------

    private static Exception SampleException()
        => new InvalidOperationException("Sample exception for testing the dialog.");

    private static Exception ConfirmException()
        => new InvalidOperationException("Do you want to retry the operation?");

    private void Show(Exception ex)
        => Show(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Warning);

    private void Show(Exception ex, ExceptionMessageBoxButtons buttons)
        => Show(ex, buttons, ExceptionMessageBoxSymbol.Warning);

    private void Show(Exception ex, ExceptionMessageBoxButtons buttons, ExceptionMessageBoxSymbol symbol)
    {
        var box = new ExceptionMessageBox(ex, buttons, symbol)
        {
            ShowToolBar = true,
        };
        box.Show(this);
    }
}
