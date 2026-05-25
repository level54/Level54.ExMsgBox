using System.Drawing;
using FluentAssertions;
using Level54.ExMsgBox.Internal;
using Xunit;

namespace Level54.ExMsgBox.Tests;

public class SymbolMapperTests
{
    [Fact]
    public void None_returns_null()
    {
        SymbolMapper.ResolveIcon(ExceptionMessageBoxSymbol.None).Should().BeNull();
    }

    [Theory]
    [InlineData(ExceptionMessageBoxSymbol.Warning)]
    [InlineData(ExceptionMessageBoxSymbol.Exclamation)]
    public void Warning_family_maps_to_SystemIcons_Warning(ExceptionMessageBoxSymbol symbol)
    {
        SymbolMapper.ResolveIcon(symbol).Should().BeSameAs(SystemIcons.Warning);
    }

    [Theory]
    [InlineData(ExceptionMessageBoxSymbol.Information)]
    [InlineData(ExceptionMessageBoxSymbol.Asterisk)]
    public void Information_family_maps_to_SystemIcons_Information(ExceptionMessageBoxSymbol symbol)
    {
        SymbolMapper.ResolveIcon(symbol).Should().BeSameAs(SystemIcons.Information);
    }

    [Theory]
    [InlineData(ExceptionMessageBoxSymbol.Error)]
    [InlineData(ExceptionMessageBoxSymbol.Hand)]
    public void Error_family_maps_to_SystemIcons_Error(ExceptionMessageBoxSymbol symbol)
    {
        SymbolMapper.ResolveIcon(symbol).Should().BeSameAs(SystemIcons.Error);
    }

    [Fact]
    public void Stop_alias_resolves_same_as_Error()
    {
        // Stop = Error = 3; this confirms the alias path produces the same icon.
        SymbolMapper.ResolveIcon(ExceptionMessageBoxSymbol.Stop)
            .Should().BeSameAs(SystemIcons.Error);
    }

    [Fact]
    public void Question_maps_to_SystemIcons_Question()
    {
        SymbolMapper.ResolveIcon(ExceptionMessageBoxSymbol.Question)
            .Should().BeSameAs(SystemIcons.Question);
    }
}
