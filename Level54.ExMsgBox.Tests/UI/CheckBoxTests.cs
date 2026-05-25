using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using Xunit;

namespace Level54.ExMsgBox.Tests.UI;

[Collection(nameof(UICollection))]
public class CheckBoxTests
{
    [SkippableFact]
    public void Checkbox_state_roundtrips_when_user_checks_then_dismisses()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=checkbox-off");
        try
        {
            var window = DialogSmokeTests.WaitForMainWindow(app, automation)!;

            var chk = window.FindFirstDescendant(cf => cf.ByAutomationId("chkDontShow"))?.AsCheckBox();
            chk.Should().NotBeNull();
            chk!.IsChecked.Should().Be(false);
            chk.Toggle();
            chk.IsChecked.Should().Be(true);

            var ok = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
            ok!.Invoke();
            DialogSmokeTests.WaitForExit(app).Should().BeTrue();

            // Harness exit code is 0 when IsCheckBoxChecked == true after Show, 1 otherwise.
            app.ExitCode.Should().Be(0, "checkbox was toggled on before clicking OK");
        }
        finally
        {
            DialogSmokeTests.CleanUp(app);
        }
    }

    [SkippableFact]
    public void Checkbox_left_off_yields_unchecked_state()
    {
        Skip.IfNot(HarnessLocator.CanRunUiTests, "Requires interactive desktop session");

        using var automation = new UIA3Automation();
        var app = Application.Launch(HarnessLocator.HarnessExePath, "--scenario=checkbox-off");
        try
        {
            var window = DialogSmokeTests.WaitForMainWindow(app, automation)!;

            var chk = window.FindFirstDescendant(cf => cf.ByAutomationId("chkDontShow"))?.AsCheckBox();
            chk!.IsChecked.Should().Be(false);

            var ok = window.FindFirstDescendant(cf => cf.ByAutomationId("btn1"))?.AsButton();
            ok!.Invoke();
            DialogSmokeTests.WaitForExit(app).Should().BeTrue();

            app.ExitCode.Should().Be(1, "checkbox was left unchecked");
        }
        finally
        {
            DialogSmokeTests.CleanUp(app);
        }
    }
}
