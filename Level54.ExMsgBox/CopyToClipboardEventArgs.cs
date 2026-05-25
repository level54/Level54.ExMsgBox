using System;

namespace Level54.ExMsgBox;

public sealed class CopyToClipboardEventArgs : EventArgs
{
    public CopyToClipboardEventArgs(string clipboardText)
    {
        ClipboardText = clipboardText ?? string.Empty;
    }

    public CopyToClipboardEventArgs() : this(string.Empty) { }

    public string ClipboardText { get; }

    public bool EventHandled { get; set; }
}
