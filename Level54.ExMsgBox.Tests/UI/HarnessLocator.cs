using System;
using System.IO;
using System.Reflection;

namespace Level54.ExMsgBox.Tests.UI;

internal static class HarnessLocator
{
    public static string HarnessExePath
    {
        get
        {
            var testAsm = Assembly.GetExecutingAssembly().Location;
            var testBin = Path.GetDirectoryName(testAsm)!;
            // testBin = ...\Level54.ExMsgBox.Tests\bin\<config>\net10.0-windows
            // harness = ...\Level54.ExMsgBox.Harness\bin\<config>\net10.0-windows\Level54.ExMsgBox.Harness.exe
            var config = Path.GetFileName(Path.GetDirectoryName(testBin)!);    // Debug / Release
            var tfm = Path.GetFileName(testBin);                                // net10.0-windows
            var solutionDir = Path.GetFullPath(Path.Combine(testBin, "..", "..", "..", ".."));
            var harnessExe = Path.Combine(
                solutionDir,
                "Level54.ExMsgBox.Harness",
                "bin",
                config,
                tfm,
                "Level54.ExMsgBox.Harness.exe");

            if (!File.Exists(harnessExe))
            {
                throw new FileNotFoundException(
                    $"Harness EXE not found at expected path. Build the harness first.",
                    harnessExe);
            }
            return harnessExe;
        }
    }

    public static bool CanRunUiTests => Environment.UserInteractive;
}
