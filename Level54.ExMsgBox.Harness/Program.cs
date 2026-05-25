using System;
using System.Linq;
using System.Windows.Forms;
using Level54.ExMsgBox;

namespace Level54.ExMsgBox.Harness;

internal static class Program
{
    [STAThread]
    private static int Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        var scenario = ParseScenario(args) ?? "simple";

        try
        {
            return scenario switch
            {
                "simple" => Scenarios.RunSimple(),
                "nested" => Scenarios.RunNested(),
                "sql" => Scenarios.RunSql(),
                "checkbox-on" => Scenarios.RunCheckBox(preChecked: true),
                "checkbox-off" => Scenarios.RunCheckBox(preChecked: false),
                "copy-intercept" => Scenarios.RunCopyIntercept(),
                _ => Fail($"Unknown scenario: {scenario}"),
            };
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Harness failure: {ex}");
            return 100;
        }
    }

    private static string? ParseScenario(string[] args)
    {
        const string prefix = "--scenario=";
        var arg = args.FirstOrDefault(a => a.StartsWith(prefix, StringComparison.Ordinal));
        return arg?[prefix.Length..];
    }

    private static int Fail(string reason)
    {
        Console.Error.WriteLine(reason);
        return 101;
    }
}
