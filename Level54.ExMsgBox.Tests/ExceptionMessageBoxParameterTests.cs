using System;
using System.ComponentModel;
using FluentAssertions;
using Xunit;

namespace Level54.ExMsgBox.Tests;

public class ExceptionMessageBoxParameterTests
{
    [Fact]
    public void Show_throws_when_message_null_and_text_empty()
    {
        var box = new ExceptionMessageBox();
        Action act = () => box.Show(null);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Show_throws_NotSupported_for_Custom_buttons()
    {
        var box = new ExceptionMessageBox(new Exception("x"))
        {
            Buttons = ExceptionMessageBoxButtons.Custom
        };
        Action act = () => box.Show(null);
        act.Should().Throw<NotSupportedException>();
    }

    [Fact]
    public void Show_throws_InvalidEnumArgument_for_invalid_Buttons()
    {
        var box = new ExceptionMessageBox(new Exception("x"))
        {
            Buttons = (ExceptionMessageBoxButtons)999
        };
        Action act = () => box.Show(null);
        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Show_throws_InvalidEnumArgument_for_invalid_Symbol()
    {
        var box = new ExceptionMessageBox(new Exception("x"))
        {
            Symbol = (ExceptionMessageBoxSymbol)999
        };
        Action act = () => box.Show(null);
        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Show_throws_InvalidEnumArgument_for_invalid_DefaultButton()
    {
        var box = new ExceptionMessageBox(new Exception("x"))
        {
            DefaultButton = (ExceptionMessageBoxDefaultButton)999
        };
        Action act = () => box.Show(null);
        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Show_throws_when_DefaultButton_out_of_range_for_Buttons_set()
    {
        // OK has only one button (Button1); requesting Button3 is out of range.
        var box = new ExceptionMessageBox(new Exception("x"))
        {
            Buttons = ExceptionMessageBoxButtons.OK,
            DefaultButton = ExceptionMessageBoxDefaultButton.Button3
        };
        Action act = () => box.Show(null);
        act.Should().Throw<InvalidEnumArgumentException>();
    }

    [Fact]
    public void Constructor_with_text_does_not_throw_on_Show_until_dialog_opens()
    {
        // Show with text-only should pass validation (Message is null but Text is set).
        // We can't actually open a dialog in unit tests, so we only assert that the
        // ArgumentNullException for null+empty isn't raised.
        var box = new ExceptionMessageBox(text: "Hi there");

        // We bypass the actual dialog by triggering only validation. Validate() is
        // internal; calling it here is the unit-level check.
        Action act = () => box.ValidateForShow();
        act.Should().NotThrow();
    }
}
