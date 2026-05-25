using System;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using Xunit;

namespace Level54.ExMsgBox.Tests.UI;

[Collection(nameof(UICollection))]
public class LayoutRegressionTests
{
    // Regression for the "dialog collapses so only the toolbar is visible" bug.
    // Without this guard, ComputeClientSize was called before layout had settled and
    // produced a tiny ClientSize that clipped the icon, message, and OK button.

    [SkippableFact]
    public void Simple_dialog_is_wide_enough_to_show_message_and_button()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=simple");
        try
        {
            var window = DialogSmokeTests.WaitForMainWindow(app, automation)!;

            // BoundingRectangle's reported size depends on the DPI awareness of the test process,
            // so it isn't a reliable absolute. The hard requirement is that the key elements
            // (primary message, OK button) are visible and lie inside the window bounds.

            var primary = window.FindFirstDescendant(cf => cf.ByAutomationId("lblPrimaryMessage"));
            primary.Should().NotBeNull();
            primary!.IsOffscreen.Should().BeFalse("the primary message must be visible");

            var ok = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"));
            ok.Should().NotBeNull();
            ok!.IsOffscreen.Should().BeFalse("the OK button must be visible");

            // The OK button's bounds must be inside the window's bounds.
            var btnRect = ok.BoundingRectangle;
            window.BoundingRectangle.Contains(btnRect).Should().BeTrue(
                $"OK button {btnRect} must lie inside window {window.BoundingRectangle}");

            ok.AsButton().Invoke();
            DialogSmokeTests.WaitForExit(app);
        }
        finally
        {
            DialogSmokeTests.CleanUp(app);
        }
    }

    [SkippableFact]
    public void Nested_dialog_grows_to_show_inner_exception_labels()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=nested");
        try
        {
            var window = DialogSmokeTests.WaitForMainWindow(app, automation)!;

            // Each inner exception label must be visible (not offscreen, not clipped).
            foreach (var id in new[] { "lblPrimaryMessage", "lblInner1", "lblInner2" })
            {
                var label = window.FindFirstDescendant(cf => cf.ByAutomationId(id));
                label.Should().NotBeNull($"{id} must exist");
                label!.IsOffscreen.Should().BeFalse($"{id} must be visible");

                var lblRect = label.BoundingRectangle;
                window.BoundingRectangle.Contains(lblRect).Should().BeTrue(
                    $"{id} {lblRect} must lie inside window {window.BoundingRectangle}");
            }

            var ok = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
            ok!.Invoke();
            DialogSmokeTests.WaitForExit(app);
        }
        finally
        {
            DialogSmokeTests.CleanUp(app);
        }
    }
}
