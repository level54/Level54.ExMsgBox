using System;
using FluentAssertions;
using Xunit;

namespace Level54.ExMsgBox.Tests;

public class CopyToClipboardEventTests
{
    [Fact]
    public void RaiseCopyToClipboard_returns_false_when_no_handler_attached()
    {
        var box = new ExceptionMessageBox(new Exception("x"));
        box.RaiseCopyToClipboard("payload").Should().BeFalse();
    }

    [Fact]
    public void RaiseCopyToClipboard_invokes_handler_with_expected_text()
    {
        var box = new ExceptionMessageBox(new Exception("x"));
        string? captured = null;
        object? capturedSender = null;
        box.OnCopyToClipboard += (sender, e) =>
        {
            capturedSender = sender;
            captured = e.ClipboardText;
        };

        box.RaiseCopyToClipboard("the-payload");

        captured.Should().Be("the-payload");
        capturedSender.Should().BeSameAs(box);
    }

    [Fact]
    public void RaiseCopyToClipboard_returns_true_when_handler_sets_EventHandled()
    {
        var box = new ExceptionMessageBox(new Exception("x"));
        box.OnCopyToClipboard += (_, e) => e.EventHandled = true;

        box.RaiseCopyToClipboard("payload").Should().BeTrue();
    }

    [Fact]
    public void RaiseCopyToClipboard_returns_false_when_handler_does_not_set_EventHandled()
    {
        var box = new ExceptionMessageBox(new Exception("x"));
        box.OnCopyToClipboard += (_, _) => { /* no-op */ };

        box.RaiseCopyToClipboard("payload").Should().BeFalse();
    }
}
