using System;
using FluentAssertions;
using Level54.ExMsgBox.Internal;
using Xunit;

namespace Level54.ExMsgBox.Tests;

public class MessageTextBuilderTests
{
    // ---------- BuildPrimaryText ----------

    [Fact]
    public void Primary_returns_just_message_when_source_is_empty()
    {
        var ex = new Exception("Boom");
        MessageTextBuilder.BuildPrimaryText(ex, caption: "Error")
            .Should().Be("Boom");
    }

    [Fact]
    public void Primary_appends_source_when_source_differs_from_caption()
    {
        // Matches MS: "{message} ({source})" — bare parens, no "Source:" label.
        var ex = new Exception("Boom") { Source = "MyComponent" };
        MessageTextBuilder.BuildPrimaryText(ex, caption: "Error")
            .Should().Be("Boom (MyComponent)");
    }

    [Fact]
    public void Primary_omits_source_when_source_equals_caption()
    {
        var ex = new Exception("Boom") { Source = "MyComponent" };
        MessageTextBuilder.BuildPrimaryText(ex, caption: "MyComponent")
            .Should().Be("Boom");
    }

    [Fact]
    public void Primary_falls_back_when_message_is_empty()
    {
        var ex = new Exception("");
        MessageTextBuilder.BuildPrimaryText(ex, caption: "Error")
            .Should().Be("An unknown error occurred.");
    }

    [Fact]
    public void Primary_rejects_null_exception()
    {
        Action act = () => MessageTextBuilder.BuildPrimaryText(null!, caption: "");
        act.Should().Throw<ArgumentNullException>();
    }

    // ---------- BuildDetailsText ----------

    [Fact]
    public void Details_includes_message_and_stack_trace()
    {
        Exception ex;
        try { throw new InvalidOperationException("Things broke"); }
        catch (InvalidOperationException caught) { ex = caught; }

        var text = MessageTextBuilder.BuildDetailsText(ex, caption: "Error");

        text.Should().Contain("Things broke");
        text.Should().Contain("Program Location:");
        text.Should().Contain(nameof(Details_includes_message_and_stack_trace));
    }

    [Fact]
    public void Details_uses_equals_separator_per_exception_block()
    {
        var ex = new Exception("Boom");
        var text = MessageTextBuilder.BuildDetailsText(ex, caption: "Error");
        // Matches MS: each exception block starts with a row of '=' characters.
        text.Should().Contain("===================================");
    }

    [Fact]
    public void Details_uses_dash_separator_before_data_or_stack_section()
    {
        var ex = new Microsoft.Data.SqlClient.SqlException("Boom") { Number = 1, Server = "X" };
        var text = MessageTextBuilder.BuildDetailsText(ex, caption: "Error");
        // Matches MS: the SQL/AdvancedInformation/StackTrace section is introduced by '-'.
        text.Should().Contain("------------------------------");
    }

    [Fact]
    public void Details_renders_inner_exception_chain()
    {
        var inner2 = new InvalidOperationException("inner-2");
        var inner1 = new InvalidOperationException("inner-1", inner2);
        var outer = new Exception("outer", inner1);

        var text = MessageTextBuilder.BuildDetailsText(outer, caption: "Error");

        text.Should().Contain("outer");
        text.Should().Contain("inner-1");
        text.Should().Contain("inner-2");
        // Each exception is its own '===' block — three blocks total for the chain.
        text.Split(new[] { "===================================" }, StringSplitOptions.None).Length
            .Should().BeGreaterThanOrEqualTo(4); // n+1 fragments for n separator hits

        // outer appears before inner-1 appears before inner-2
        text.IndexOf("outer").Should().BeLessThan(text.IndexOf("inner-1"));
        text.IndexOf("inner-1").Should().BeLessThan(text.IndexOf("inner-2"));
    }

    [Fact]
    public void Details_includes_sql_block_when_exception_is_sql()
    {
        // Matches MS: SQL section uses "Server Name:" / "Error Number:" / "Line Number:"
        // and has no "SQL Server information" header — the '-' separator above it is enough.
        var ex = new Microsoft.Data.SqlClient.SqlException("DB blew up")
        {
            Number = 547,
            Class = 16,
            State = 1,
            LineNumber = 42,
            Procedure = "usp_DoStuff",
            Server = "PROD-DB-01"
        };

        var text = MessageTextBuilder.BuildDetailsText(ex, caption: "Error");

        text.Should().Contain("Server Name: PROD-DB-01");
        text.Should().Contain("Error Number: 547");
        text.Should().Contain("Severity: 16");
        text.Should().Contain("State: 1");
        text.Should().Contain("Procedure: usp_DoStuff");
        text.Should().Contain("Line Number: 42");
        text.Should().NotContain("--- SQL Server information ---");
    }

    [Fact]
    public void Details_omits_sql_block_when_exception_is_not_sql()
    {
        var ex = new InvalidOperationException("plain");
        var text = MessageTextBuilder.BuildDetailsText(ex, caption: "Error");
        text.Should().NotContain("SQL Server information");
    }

    [Fact]
    public void Details_includes_advanced_information_entries_from_Data()
    {
        // Matches MS: AdvancedInformation.* entries appear after a '-' separator with no header.
        var ex = new InvalidOperationException("boom");
        ex.Data["AdvancedInformation.Customer"] = "Acme Corp";
        ex.Data["AdvancedInformation.OrderId"] = 12345;
        ex.Data["UnrelatedKey"] = "should-not-appear";

        var text = MessageTextBuilder.BuildDetailsText(ex, caption: "Error");

        text.Should().Contain("Customer = Acme Corp");
        text.Should().Contain("OrderId = 12345");
        text.Should().NotContain("UnrelatedKey");
        text.Should().NotContain("AdvancedInformation.Customer"); // prefix stripped
        text.Should().NotContain("--- Additional information ---");
    }

    [Fact]
    public void Details_rejects_null_exception()
    {
        Action act = () => MessageTextBuilder.BuildDetailsText(null!, caption: "");
        act.Should().Throw<ArgumentNullException>();
    }

    // ---------- BuildClipboardText ----------

    [Fact]
    public void Clipboard_text_includes_caption_header_when_caption_set()
    {
        var ex = new Exception("Boom");
        var text = MessageTextBuilder.BuildClipboardText(ex, caption: "My Application", buttonLabels: null);
        text.Should().StartWith("=== My Application ===");
    }

    [Fact]
    public void Clipboard_text_omits_caption_header_when_caption_empty()
    {
        // The per-exception block uses '===' separators internally; what we're asserting
        // here is that there's no "=== <caption> ===" header line.
        var ex = new Exception("Boom");
        var text = MessageTextBuilder.BuildClipboardText(ex, caption: "", buttonLabels: null);
        text.Should().NotContain("=== ");
        text.Should().Contain("Boom");
    }

    [Fact]
    public void Clipboard_text_appends_button_list_when_provided()
    {
        var ex = new Exception("Boom");
        var text = MessageTextBuilder.BuildClipboardText(
            ex,
            caption: "Error",
            buttonLabels: new[] { "OK", "Cancel" });

        text.Should().Contain("Buttons:");
        text.Should().Contain("  - OK");
        text.Should().Contain("  - Cancel");
    }

    [Fact]
    public void Clipboard_text_omits_button_section_when_button_list_empty_or_null()
    {
        var ex = new Exception("Boom");

        MessageTextBuilder.BuildClipboardText(ex, "Error", buttonLabels: null)
            .Should().NotContain("Buttons:");

        MessageTextBuilder.BuildClipboardText(ex, "Error", buttonLabels: Array.Empty<string>())
            .Should().NotContain("Buttons:");
    }

    [Fact]
    public void Clipboard_text_includes_details_body()
    {
        var ex = new Exception("Boom");
        var text = MessageTextBuilder.BuildClipboardText(ex, "Error", new[] { "OK" });
        text.Should().Contain("Boom");
    }

    [Fact]
    public void Clipboard_text_rejects_null_exception()
    {
        Action act = () => MessageTextBuilder.BuildClipboardText(null!, caption: "", buttonLabels: null);
        act.Should().Throw<ArgumentNullException>();
    }

    // ---------- BuildAdditionalDataText (per-exception, used by Advanced Information tree) ----------

    [Fact]
    public void AdditionalData_returns_empty_for_plain_exception()
    {
        var ex = new InvalidOperationException("plain");
        MessageTextBuilder.BuildAdditionalDataText(ex).Should().BeEmpty();
    }

    [Fact]
    public void AdditionalData_contains_sql_fields_for_sql_exception()
    {
        // MS labels: "Server Name:" / "Error Number:" / "Line Number:".
        var ex = new Microsoft.Data.SqlClient.SqlException("login failed")
        {
            Number = 18456,
            Class = 14,
            State = 1,
            LineNumber = 1,
            Procedure = "sp_Login",
            Server = "DEMO-SQL-01",
        };

        var text = MessageTextBuilder.BuildAdditionalDataText(ex);

        text.Should().Contain("Server Name: DEMO-SQL-01");
        text.Should().Contain("Error Number: 18456");
        text.Should().Contain("Severity: 14");
        text.Should().Contain("State: 1");
        text.Should().Contain("Procedure: sp_Login");
        text.Should().Contain("Line Number: 1");
    }

    [Fact]
    public void AdditionalData_contains_advanced_information_entries()
    {
        var ex = new InvalidOperationException("validation failed");
        ex.Data["AdvancedInformation.CustomerId"] = "C-12345";
        ex.Data["AdvancedInformation.Field"] = "EmailAddress";
        ex.Data["UnrelatedKey"] = "ignored";

        var text = MessageTextBuilder.BuildAdditionalDataText(ex);

        text.Should().Contain("CustomerId = C-12345");
        text.Should().Contain("Field = EmailAddress");
        text.Should().NotContain("UnrelatedKey");
    }

    [Fact]
    public void AdditionalData_rejects_null_exception()
    {
        Action act = () => MessageTextBuilder.BuildAdditionalDataText(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    // ---------- HasAdditionalData (used to decide whether to show the tree node) ----------

    [Fact]
    public void HasAdditionalData_false_for_plain_exception()
    {
        MessageTextBuilder.HasAdditionalData(new InvalidOperationException("x"))
            .Should().BeFalse();
    }

    [Fact]
    public void HasAdditionalData_true_for_sql_exception()
    {
        var ex = new Microsoft.Data.SqlClient.SqlException("boom");
        MessageTextBuilder.HasAdditionalData(ex).Should().BeTrue();
    }

    [Fact]
    public void HasAdditionalData_true_when_advanced_information_present()
    {
        var ex = new InvalidOperationException("x");
        ex.Data["AdvancedInformation.Key"] = "value";
        MessageTextBuilder.HasAdditionalData(ex).Should().BeTrue();
    }

    [Fact]
    public void HasAdditionalData_false_when_only_unrelated_data_keys()
    {
        var ex = new InvalidOperationException("x");
        ex.Data["UnrelatedKey"] = "value";
        MessageTextBuilder.HasAdditionalData(ex).Should().BeFalse();
    }

    // ---------- HasTechnicalDetails (used to decide whether to show the "Show details" link) ----------

    [Fact]
    public void HasTechnicalDetails_false_for_plain_unthrown_exception()
    {
        MessageTextBuilder.HasTechnicalDetails(new InvalidOperationException("x"))
            .Should().BeFalse();
    }

    [Fact]
    public void HasTechnicalDetails_true_when_outer_has_stack_trace()
    {
        Exception caught;
        try { throw new InvalidOperationException("boom"); }
        catch (InvalidOperationException ex) { caught = ex; }

        MessageTextBuilder.HasTechnicalDetails(caught).Should().BeTrue();
    }

    [Fact]
    public void HasTechnicalDetails_true_when_inner_has_stack_trace()
    {
        Exception caught;
        try { throw new InvalidOperationException("inner"); }
        catch (InvalidOperationException inner) { caught = inner; }

        var outer = new ApplicationException("outer", caught);
        MessageTextBuilder.HasTechnicalDetails(outer).Should().BeTrue();
    }

    [Fact]
    public void HasTechnicalDetails_true_when_sql_or_advanced_data_present()
    {
        var sql = new Microsoft.Data.SqlClient.SqlException("boom");
        MessageTextBuilder.HasTechnicalDetails(sql).Should().BeTrue();

        var adv = new InvalidOperationException("x");
        adv.Data["AdvancedInformation.Key"] = "value";
        MessageTextBuilder.HasTechnicalDetails(adv).Should().BeTrue();
    }
}
