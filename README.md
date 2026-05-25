# Level54.ExMsgBox

Modern .NET 10 WinForms replacement for `Microsoft.SqlServer.MessageBox.ExceptionMessageBox`.

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](LICENSE)

## Overview

Microsoft's original `ExceptionMessageBox` only ships with SQL Server's client tooling and targets .NET Framework, which makes it awkward to use from a modern .NET 10 WinForms app. Level54.ExMsgBox is a clean-room rewrite for `net10.0-windows` that mirrors the original's API surface and visual behaviour — same dialog layout, same details expander, same SQL Server exception handling — without taking a dependency on the SQL Server GAC assemblies.

## Features

- Rich exception dialog with nested/inner-exception drill-down
- "Details" expander showing the full exception tree, `Exception.Data` entries, and a stack trace per frame
- Copy-to-clipboard with an `OnCopyToClipboard` event for app-level interception
- SQL Server-aware: extracts `Number`, `Class`, `State`, `Procedure`, `Server`, and `LineNumber` from `SqlException`
- Optional "don't show again" checkbox with two-way state
- All standard button sets (OK, OK/Cancel, Yes/No, Yes/No/Cancel, Retry/Cancel, Abort/Retry/Ignore) and symbols
- Toolbar, beep, and help-link toggles
- Zero NuGet dependencies — pure WinForms + Win32 interop

## Requirements

- .NET 10 (`net10.0-windows`)
- Windows

## Installation

### From source (current path)

```
git clone https://github.com/Level54/Level54.ExMsgBox.git
dotnet build Level54.ExMsgBox.slnx
```

Add a project reference to the library:

```xml
<ProjectReference Include="path/to/Level54.ExMsgBox/Level54.ExMsgBox.csproj" />
```

The library's csproj has `GeneratePackageOnBuild` enabled, so a `.nupkg` is also produced under `Level54.ExMsgBox/bin/` on every build if you'd rather consume it as a local package.

### From NuGet (planned)

Once published:

```
dotnet add package Level54.ExMsgBox
```

The package is not yet on nuget.org.

## Quick start

```csharp
using Level54.ExMsgBox;

try
{
    DoWork();
}
catch (Exception ex)
{
    ExceptionMessageBox.Show(this, ex);
}
```

Instance API for full customisation:

```csharp
var box = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.RetryCancel, ExceptionMessageBoxSymbol.Error)
{
    Caption = "Database operation failed",
    ShowCheckBox = true,
    CheckBoxText = "Don't show this again",
};

var result = box.Show(this);

if (box.IsCheckBoxChecked)
{
    SuppressFutureDialogs();
}
```

## Compatibility with Microsoft's original

The public API — class name, properties, constructors, and the `ExceptionMessageBoxButtons` / `ExceptionMessageBoxSymbol` / `ExceptionMessageBoxDefaultButton` enums — matches `Microsoft.SqlServer.MessageBox.ExceptionMessageBox`. Migrating an existing app is generally a `using` swap:

```diff
- using Microsoft.SqlServer.MessageBox;
+ using Level54.ExMsgBox;
```

The namespace differs, so this is a source-compatible migration, not a binary-compatible one. The `WinFormsTest472/` project in this repo wraps Microsoft's original implementation on .NET Framework 4.7.2 and can be run side-by-side with `WinFormsTest/` for visual comparison.

## Project layout

| Project | Purpose |
| --- | --- |
| `Level54.ExMsgBox/` | The library itself. |
| `Level54.ExMsgBox.Harness/` | Interactive demo for manual testing. |
| `Level54.ExMsgBox.Tests/` | xUnit unit tests plus FlaUI-driven UI/layout tests. |
| `WinFormsTest/` | .NET 10 sample app exercising the new library. |
| `WinFormsTest472/` | .NET Framework 4.7.2 reference app using Microsoft's original, for side-by-side comparison. |

The harness accepts a `--scenario` argument, with values including `simple`, `nested`, `sql`, `checkbox-on`, `checkbox-off`, and `copy-intercept`.

## Building and testing

```
dotnet build Level54.ExMsgBox.slnx
dotnet test Level54.ExMsgBox.Tests
dotnet run --project Level54.ExMsgBox.Harness -- --scenario=nested
```

The FlaUI-based UI tests in `Level54.ExMsgBox.Tests` launch the harness as a real WinForms process, so they must run on a Windows desktop session with an interactive window station.

## Contributing

Pull requests are welcome. Please run the full test suite (`dotnet test`) before submitting, and exercise the harness manually for any change that affects dialog rendering — the FlaUI layout regression tests catch most things, but a quick visual check against `WinFormsTest472` is the surest way to confirm you haven't drifted from the original's look and feel.

## License

Released under the [GNU General Public License v3](LICENSE).

Copyright © Level54 2026.
