using System;
using System.Linq;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using FluentAssertions;
using Xunit;

namespace Level54.ExMsgBox.Tests.UI;

[Collection(nameof(UICollection))]
public class DialogSmokeTests
{
    [SkippableFact]
    public void Simple_dialog_shows_message_and_OK_returns_zero()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=simple");
        try
        {
            var window = WaitForMainWindow(app, automation);
            window.Should().NotBeNull();

            var primary = window!.FindFirstDescendant(cf => cf.ByAutomationId("lblPrimaryMessage"));
            primary.Should().NotBeNull();
            primary!.AsLabel().Text.Should().Contain("Simple harness exception");

            var okButton = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
            okButton.Should().NotBeNull("the OK button should be present");
            okButton!.Invoke();

            WaitForExit(app).Should().BeTrue("the harness process should exit after OK is clicked");
            app.ExitCode.Should().Be(0);
        }
        finally
        {
            CleanUp(app);
        }
    }

    [SkippableFact]
    public void Nested_dialog_shows_inner_exception_labels()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=nested");
        try
        {
            var window = WaitForMainWindow(app, automation);
            window.Should().NotBeNull();

            // The primary label + at least one inner label by AccessibleName.
            var primaryLabel = window!.FindFirstDescendant(cf => cf.ByAutomationId("lblPrimaryMessage"));
            primaryLabel.Should().NotBeNull();
            primaryLabel!.AsLabel().Text.Should().Contain("Top-level failure");

            var inner1 = window.FindFirstDescendant(cf => cf.ByAutomationId("lblInner1"));
            inner1.Should().NotBeNull();
            inner1!.AsLabel().Text.Should().Contain("Mid cause");

            var inner2 = window.FindFirstDescendant(cf => cf.ByAutomationId("lblInner2"));
            inner2.Should().NotBeNull();
            inner2!.AsLabel().Text.Should().Contain("Leaf cause");

            var okButton = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
            okButton!.Invoke();
            WaitForExit(app);
        }
        finally
        {
            CleanUp(app);
        }
    }

    internal static Window? WaitForMainWindow(FlaUI.Core.Application app, AutomationBase automation, int timeoutMs = 8000)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        while (sw.ElapsedMilliseconds < timeoutMs)
        {
            try
            {
                var windows = app.GetAllTopLevelWindows(automation);
                var hit = windows.FirstOrDefault(w => w.AutomationId == "ExceptionMessageBoxForm" || w.Name == "Error" || w.Name == "Harness");
                if (hit is not null) return hit;
            }
            catch
            {
                // Window may not be ready yet; ignore and retry.
            }
            Thread.Sleep(150);
        }
        return null;
    }

    internal static void CleanUp(FlaUI.Core.Application app)
    {
        try
        {
            if (!app.HasExited) app.Close();
        }
        catch { /* best effort */ }
        app.Dispose();
    }

    internal static AutomationElement? FindToolstripButton(Window window, string text)
    {
        // WinForms ToolStripButton may surface as Button OR MenuItem depending on the renderer.
        // First try by name without control-type restriction.
        var byName = window.FindFirstDescendant(cf => cf.ByName(text));
        if (byName is not null) return byName;

        // Fallback: walk all descendants and match by name (case-insensitive).
        foreach (var child in window.FindAllDescendants())
        {
            if (string.Equals(child.Name, text, StringComparison.OrdinalIgnoreCase))
                return child;
        }
        return null;
    }

    internal static bool WaitForExit(FlaUI.Core.Application app, int timeoutMs = 5000)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        while (sw.ElapsedMilliseconds < timeoutMs)
        {
            if (app.HasExited) return true;
            Thread.Sleep(100);
        }
        return app.HasExited;
    }
}
