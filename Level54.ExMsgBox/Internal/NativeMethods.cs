using System.Runtime.InteropServices;

namespace Level54.ExMsgBox.Internal;

internal static class NativeMethods
{
    public const uint MB_OK = 0x00000000;
    public const uint MB_ICONHAND = 0x00000010;
    public const uint MB_ICONQUESTION = 0x00000020;
    public const uint MB_ICONEXCLAMATION = 0x00000030;
    public const uint MB_ICONASTERISK = 0x00000040;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool MessageBeep(uint uType);
}
