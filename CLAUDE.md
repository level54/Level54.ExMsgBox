# CLAUDE.md

Behavioral guidelines to reduce common LLM coding mistakes. Merge with project-specific instructions as needed.

**Tradeoff:** These guidelines bias toward caution over speed. For trivial tasks, use judgment.

## 1. Think Before Coding

**Don't assume. Don't hide confusion. Surface tradeoffs.**

Before implementing:
- State your assumptions explicitly. If uncertain, ask.
- If multiple interpretations exist, present them - don't pick silently.
- If a simpler approach exists, say so. Push back when warranted.
- If something is unclear, stop. Name what's confusing. Ask.

## 2. Simplicity First

**Minimum code that solves the problem. Nothing speculative.**

- No features beyond what was asked.
- No abstractions for single-use code.
- No "flexibility" or "configurability" that wasn't requested.
- No error handling for impossible scenarios.
- If you write 200 lines and it could be 50, rewrite it.

Ask yourself: "Would a senior engineer say this is overcomplicated?" If yes, simplify.

## 3. Surgical Changes

**Touch only what you must. Clean up only your own mess.**

When editing existing code:
- Don't "improve" adjacent code, comments, or formatting.
- Don't refactor things that aren't broken.
- Match existing style, even if you'd do it differently.
- If you notice unrelated dead code, mention it - don't delete it.

When your changes create orphans:
- Remove imports/variables/functions that YOUR changes made unused.
- Don't remove pre-existing dead code unless asked.

The test: Every changed line should trace directly to the user's request.

## 4. Goal-Driven Execution

**Define success criteria. Loop until verified.**

Transform tasks into verifiable goals:
- "Add validation" → "Write tests for invalid inputs, then make them pass"
- "Fix the bug" → "Write a test that reproduces it, then make it pass"
- "Refactor X" → "Ensure tests pass before and after"

For multi-step tasks, state a brief plan:
```
1. [Step] → verify: [check]
2. [Step] → verify: [check]
3. [Step] → verify: [check]
```

Strong success criteria let you loop independently. Weak criteria ("make it work") require constant clarification.

---

**These guidelines are working if:** fewer unnecessary changes in diffs, fewer rewrites due to overcomplication, and clarifying questions come before implementation rather than after mistakes.

---

# Project: Level54.ExMsgBox

Modern .NET 10 WinForms replacement for `Microsoft.SqlServer.MessageBox.ExceptionMessageBox`. Clean-room rewrite targeting `net10.0-windows` that mirrors the original's public API and visual behaviour without depending on the SQL Server GAC assemblies. Zero NuGet dependencies — pure WinForms + Win32 interop. GPLv3.

## Layout

| Project | Purpose |
| --- | --- |
| `Level54.ExMsgBox/` | The library. Public API at the root; implementation under `Internal/`. |
| `Level54.ExMsgBox.Harness/` | Console app that launches a dialog per `--scenario`; driven by the UI tests. |
| `Level54.ExMsgBox.Tests/` | xUnit unit tests + FlaUI-driven UI/layout regression tests. |
| `WinFormsTest/` | .NET 10 sample app exercising this library. |
| `WinFormsTest472/` | .NET Framework 4.7.2 app using Microsoft's *original*, for side-by-side visual comparison. Do not modify to fix our bugs — it's the reference. |

## Build & test

```
dotnet build Level54.ExMsgBox.slnx
dotnet test Level54.ExMsgBox.Tests
dotnet run --project Level54.ExMsgBox.Harness -- --scenario=nested
```

Harness scenarios include: `simple`, `nested`, `sql`, `checkbox-on`, `checkbox-off`, `copy-intercept`.

## Conventions & constraints

- **API compatibility is the contract.** The class name, properties, constructors, and the `ExceptionMessageBoxButtons` / `ExceptionMessageBoxSymbol` / `ExceptionMessageBoxDefaultButton` enums must match Microsoft's original (source-compatible migration via a `using` swap). Don't rename or re-shape public members without flagging the break.
- **Visual fidelity matters.** Changes affecting dialog rendering should be checked against `WinFormsTest472` (the original). The FlaUI layout regression tests in `Level54.ExMsgBox.Tests` guard most of this.
- Library is `Nullable` enabled with `ImplicitUsings`. Keep new code nullable-clean.
- Implementation detail lives under `Internal/`; the library exposes internals to the Tests and Harness projects via `InternalsVisibleTo`, so tests can target internal types directly.
- `GeneratePackageOnBuild` is on — every library build also emits a `.nupkg`.
- **UI tests need a real desktop.** The FlaUI tests launch the harness as an actual WinForms process and require an interactive Windows window station; they use `SkippableFact` and will skip rather than fail in headless environments.
- Test stack: xUnit, FluentAssertions, FlaUI.UIA3.
