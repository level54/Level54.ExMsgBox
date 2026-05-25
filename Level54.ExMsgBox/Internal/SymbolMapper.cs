using System.Drawing;

namespace Level54.ExMsgBox.Internal;

internal static class SymbolMapper
{
    public static Icon? ResolveIcon(ExceptionMessageBoxSymbol symbol) => symbol switch
    {
        ExceptionMessageBoxSymbol.None => null,
        ExceptionMessageBoxSymbol.Warning => SystemIcons.Warning,
        ExceptionMessageBoxSymbol.Exclamation => SystemIcons.Warning,
        ExceptionMessageBoxSymbol.Information => SystemIcons.Information,
        ExceptionMessageBoxSymbol.Asterisk => SystemIcons.Information,
        ExceptionMessageBoxSymbol.Error => SystemIcons.Error,
        // Stop = 3 same value as Error (enum alias), Hand = 7
        ExceptionMessageBoxSymbol.Hand => SystemIcons.Error,
        ExceptionMessageBoxSymbol.Question => SystemIcons.Question,
        _ => null,
    };
}
