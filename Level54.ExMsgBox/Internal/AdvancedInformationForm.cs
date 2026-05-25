using System;
using System.Windows.Forms;

namespace Level54.ExMsgBox.Internal;

internal sealed partial class AdvancedInformationForm : Form
{
    // Selecting the "All messages" root shows the full dump.
    // Other nodes carry a NodeTag identifying which slice of which exception to show.
    private enum NodeKind { Message, AdditionalData, ProgramLocation }

    private sealed record NodeTag(NodeKind Kind, Exception Exception);

    private readonly Exception _exception;
    private readonly string _caption;

    public AdvancedInformationForm(Exception exception, string caption)
    {
        _exception = exception ?? throw new ArgumentNullException(nameof(exception));
        _caption = caption ?? string.Empty;

        InitializeComponent();

        Load += OnLoadInitialise;
        tvComponents.AfterSelect += OnTreeNodeSelected;
        btnCopy.Click += OnCopyClick;
    }

    private void OnLoadInitialise(object? sender, EventArgs e)
    {
        BuildTree();
    }

    private void BuildTree()
    {
        tvComponents.BeginUpdate();
        try
        {
            tvComponents.Nodes.Clear();

            // Root — selecting it shows the full BuildDetailsText dump
            var rootNode = new TreeNode("All messages") { Tag = null };
            tvComponents.Nodes.Add(rootNode);

            for (Exception? ex = _exception; ex is not null; ex = ex.InnerException)
            {
                var parent = new TreeNode(TruncateForTree(ex.Message)) { Tag = null };
                rootNode.Nodes.Add(parent);

                parent.Nodes.Add(new TreeNode("Message") { Tag = new NodeTag(NodeKind.Message, ex) });

                if (MessageTextBuilder.HasAdditionalData(ex))
                {
                    parent.Nodes.Add(new TreeNode("Additional data") { Tag = new NodeTag(NodeKind.AdditionalData, ex) });
                }

                if (!string.IsNullOrEmpty(ex.StackTrace))
                {
                    parent.Nodes.Add(new TreeNode("Program Location") { Tag = new NodeTag(NodeKind.ProgramLocation, ex) });
                }
            }

            tvComponents.ExpandAll();
            tvComponents.SelectedNode = rootNode;
        }
        finally
        {
            tvComponents.EndUpdate();
        }
    }

    private void OnTreeNodeSelected(object? sender, TreeViewEventArgs e)
    {
        txtDetails.Text = e.Node?.Tag switch
        {
            NodeTag tag => RenderNode(tag),
            _ => MessageTextBuilder.BuildDetailsText(_exception, _caption),
        };
        txtDetails.Select(0, 0);
        txtDetails.ScrollToCaret();
    }

    private static string RenderNode(NodeTag tag) => tag.Kind switch
    {
        NodeKind.Message => string.IsNullOrEmpty(tag.Exception.Message)
            ? MessageTextBuilder.UnknownErrorFallback
            : tag.Exception.Message,
        NodeKind.AdditionalData => MessageTextBuilder.BuildAdditionalDataText(tag.Exception),
        NodeKind.ProgramLocation => tag.Exception.StackTrace ?? string.Empty,
        _ => string.Empty,
    };

    private void OnCopyClick(object? sender, EventArgs e)
    {
        var text = txtDetails.SelectionLength > 0 ? txtDetails.SelectedText : txtDetails.Text;
        if (string.IsNullOrEmpty(text)) return;
        try { Clipboard.SetText(text); }
        catch { /* clipboard contention; best effort */ }
    }

    private static string TruncateForTree(string? message)
    {
        if (string.IsNullOrEmpty(message)) return MessageTextBuilder.UnknownErrorFallback;

        // Single line, trimmed; tree nodes wrap badly with long text.
        var firstLine = message;
        var newlineIdx = firstLine.IndexOfAny(new[] { '\r', '\n' });
        if (newlineIdx >= 0) firstLine = firstLine.Substring(0, newlineIdx);

        const int MaxLen = 80;
        if (firstLine.Length > MaxLen) firstLine = firstLine.Substring(0, MaxLen - 1) + "…";
        return firstLine;
    }

}
