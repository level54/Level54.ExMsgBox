using System;
using System.IO;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using Xunit;

namespace Level54.ExMsgBox.Tests.UI;

[Collection(nameof(UICollection))]
public class DetailsAndCopyTests
{
    [SkippableFact]
    public void Show_details_opens_details_window_with_sql_block()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=sql");
        try
        {
            var window = DialogSmokeTests.WaitForMainWindow(app, automation)!;
            var detailsLink = window.FindFirstDescendant(cf => cf.ByAutomationId("btnDetails"));
            detailsLink.Should().NotBeNull("show details link should exist when the exception has technical details");
            // Mouse-click rather than Invoke — the click opens a modal child, which would
            // block the message pump and time out a UIA Invoke.
            detailsLink!.Click();

            // Wait for the details window: try ModalWindows first, then any child window
            // with our AutomationId. ModalWindows can be racy in Release.
            AutomationElement? details = null;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < 8000 && details is null)
            {
                if (window.ModalWindows.Length > 0)
                {
                    details = window.ModalWindows[0];
                    break;
                }

                details = automation.GetDesktop()
                    .FindFirstDescendant(cf => cf.ByAutomationId("AdvancedInformationForm"));
                if (details is not null) break;

                Thread.Sleep(100);
            }
            details.Should().NotBeNull("the AdvancedInformationForm should open as modal");

            var textBox = details!.FindFirstDescendant(cf => cf.ByAutomationId("txtDetails"))?.AsTextBox();
            textBox.Should().NotBeNull();
            var body = textBox!.Text;
            body.Should().Contain("Login failed for user 'demo'");
            body.Should().Contain("Server Name: DEMO-SQL-01");
            body.Should().Contain("Error Number: 18456");

            var close = details.FindFirstDescendant(cf => cf.ByAutomationId("btnClose"))?.AsButton();
            close!.Invoke();

            var ok = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
            ok!.Invoke();
            DialogSmokeTests.WaitForExit(app);
        }
        finally
        {
            DialogSmokeTests.CleanUp(app);
        }
    }

    [SkippableFact]
    public void Copy_intercept_handler_suppresses_clipboard_write()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        var capturePath = Path.Combine(Path.GetTempPath(), $"exmsgbox-copy-{Guid.NewGuid():N}.txt");
        var sentinel = $"sentinel-{Guid.NewGuid():N}";

        // Pre-seed the clipboard via the harness env-var capture file — actually we use a different mechanism:
        // The handler in the harness sets EventHandled=true so the library will NOT touch the clipboard.
        // We pre-set the OS clipboard before clicking Copy; if EventHandled works, our sentinel survives.

        try
        {
            Environment.SetEnvironmentVariable("EXMSGBOX_HARNESS_COPY_CAPTURE", capturePath);

            // Set the sentinel via a quick STA helper before launching the harness.
            SetClipboardSta(sentinel);

            using var automation = new UIA3Automation();
            var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=copy-intercept");
            try
            {
                var window = DialogSmokeTests.WaitForMainWindow(app, automation)!;
                var copyLink = window.FindFirstDescendant(cf => cf.ByAutomationId("btnCopy"));
                copyLink.Should().NotBeNull("copy link should exist");
                copyLink!.Click();
                Thread.Sleep(500); // let the click propagate

                // Harness captured the clipboard text it would have written
                File.Exists(capturePath).Should().BeTrue("the harness should record the intercepted text");
                File.ReadAllText(capturePath).Should().Contain("Intercept scenario");

                // Clipboard contents should still be our sentinel — handler set EventHandled=true.
                GetClipboardSta().Should().Be(sentinel);

                var ok = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
                ok!.Invoke();
                DialogSmokeTests.WaitForExit(app);
            }
            finally
            {
                DialogSmokeTests.CleanUp(app);
            }
        }
        finally
        {
            Environment.SetEnvironmentVariable("EXMSGBOX_HARNESS_COPY_CAPTURE", null);
            try { if (File.Exists(capturePath)) File.Delete(capturePath); } catch { }
        }
    }

    private static void SetClipboardSta(string value)
    {
        Exception? captured = null;
        var t = new Thread(() =>
        {
            try { System.Windows.Forms.Clipboard.SetText(value); }
            catch (Exception ex) { captured = ex; }
        });
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
        t.Join();
        if (captured is not null) throw captured;
    }

    private static string GetClipboardSta()
    {
        string? value = null;
        var t = new Thread(() =>
        {
            try { value = System.Windows.Forms.Clipboard.GetText(); }
            catch { value = null; }
        });
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
        t.Join();
        return value ?? string.Empty;
    }
}
