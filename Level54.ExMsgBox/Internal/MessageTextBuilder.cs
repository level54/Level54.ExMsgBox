using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Level54.ExMsgBox.Internal;

internal static class MessageTextBuilder
{
    internal const string UnknownErrorFallback = "An unknown error occurred.";

    // Matches the separator widths used by Microsoft.ExceptionMessageBox.dll's
    // BuildAdvancedInfo(ex, AdvancedInfoType.All).
    private const string EqualsSeparator = "===================================";   // 35 '='
    private const string DashSeparator   = "------------------------------";        //  30 '-'

    private const string ProgramLocationHeader = "Program Location:";
    private const string AdvancedInformationDataPrefix = "AdvancedInformation.";

    // ---------- Primary text (main dialog top label) ----------

    public static string BuildPrimaryText(Exception exception, string? caption)
    {
        if (exception is null) throw new ArgumentNullException(nameof(exception));

        var message = string.IsNullOrEmpty(exception.Message) ? UnknownErrorFallback : exception.Message;
        var source = exception.Source;

        // Source rendered as " ({source})" — matches the MS dialog's primary label format.
        // Suppressed when source equals caption (avoids duplication with the window title).
        if (!string.IsNullOrEmpty(source) && !string.Equals(source, caption, StringComparison.Ordinal))
        {
            return $"{message} ({source})";
        }

        return message;
    }

    // ---------- Clipboard text (Copy message) ----------

    public static string BuildClipboardText(
        Exception exception,
        string? caption,
        IReadOnlyList<string>? buttonLabels)
    {
        if (exception is null) throw new ArgumentNullException(nameof(exception));

        var builder = new StringBuilder();
        if (!string.IsNullOrEmpty(caption))
        {
            builder.Append("=== ").Append(caption).AppendLine(" ===");
            builder.AppendLine();
        }

        builder.AppendLine(BuildDetailsText(exception, caption));

        if (buttonLabels is { Count: > 0 })
        {
            builder.AppendLine();
            builder.AppendLine("Buttons:");
            foreach (var label in buttonLabels)
            {
                builder.Append("  - ").AppendLine(label);
            }
        }

        return builder.ToString().TrimEnd('\r', '\n');
    }

    // ---------- Details text (Advanced Information "All messages") ----------

    public static string BuildDetailsText(Exception exception, string? caption)
    {
        if (exception is null) throw new ArgumentNullException(nameof(exception));
        _ = caption; // present for API symmetry; per-exception blocks don't use caption

        var builder = new StringBuilder();
        var first = true;

        for (Exception? ex = exception; ex is not null; ex = ex.InnerException)
        {
            if (!first) builder.AppendLine();
            AppendExceptionBlock(builder, ex);
            first = false;
        }

        return builder.ToString().TrimEnd('\r', '\n');
    }

    private static void AppendExceptionBlock(StringBuilder builder, Exception exception)
    {
        builder.AppendLine(EqualsSeparator);

        var message = string.IsNullOrEmpty(exception.Message) ? UnknownErrorFallback : exception.Message;
        builder.Append(message);
        if (!string.IsNullOrEmpty(exception.Source))
        {
            builder.Append(" (").Append(exception.Source).Append(')');
        }
        builder.AppendLine();

        var additional = BuildAdditionalDataText(exception);
        var hasStack = !string.IsNullOrEmpty(exception.StackTrace);

        if (additional.Length > 0)
        {
            builder.AppendLine();
            builder.AppendLine(DashSeparator);
            builder.AppendLine(additional);
        }

        if (hasStack)
        {
            builder.AppendLine(DashSeparator);
            builder.AppendLine(ProgramLocationHeader);
            builder.AppendLine();
            builder.AppendLine(exception.StackTrace);
        }
    }

    // ---------- Per-exception "Additional data" block (tree node view) ----------

    /// <summary>
    /// Renders the per-exception "Additional data" block — SQL fields and
    /// AdvancedInformation.* entries — without any header or stack trace. Returns
    /// empty if neither SQL info nor AdvancedInformation entries are present.
    /// </summary>
    public static string BuildAdditionalDataText(Exception exception)
    {
        if (exception is null) throw new ArgumentNullException(nameof(exception));

        var builder = new StringBuilder();
        var sqlInfo = new SqlExceptionInfo(exception);

        if (sqlInfo.IsSqlException)
        {
            if (!string.IsNullOrEmpty(sqlInfo.Server))
                builder.Append("Server Name: ").AppendLine(sqlInfo.Server);
            builder.Append("Error Number: ").AppendLine(sqlInfo.Number.ToString(CultureInfo.InvariantCulture));
            builder.Append("Severity: ").AppendLine(sqlInfo.Class.ToString(CultureInfo.InvariantCulture));
            builder.Append("State: ").AppendLine(sqlInfo.State.ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrEmpty(sqlInfo.Procedure))
                builder.Append("Procedure: ").AppendLine(sqlInfo.Procedure);
            if (sqlInfo.LineNumber != 0)
                builder.Append("Line Number: ").AppendLine(sqlInfo.LineNumber.ToString(CultureInfo.InvariantCulture));
        }

        var advancedEntries = CollectAdvancedInformation(exception);
        if (advancedEntries.Count > 0)
        {
            if (builder.Length > 0) builder.AppendLine();
            foreach (var (key, value) in advancedEntries)
            {
                builder.Append(key).Append(" = ").AppendLine(value);
            }
        }

        return builder.ToString().TrimEnd('\r', '\n');
    }

    // ---------- Predicates used by the main dialog ----------

    /// <summary>
    /// True if the given exception has SQL info or any AdvancedInformation.* entries.
    /// Used by the Advanced Information tree to decide whether to add a "Additional data" node.
    /// </summary>
    public static bool HasAdditionalData(Exception exception)
    {
        if (exception is null) throw new ArgumentNullException(nameof(exception));

        if (new SqlExceptionInfo(exception).IsSqlException) return true;

        if (exception.Data is { Count: > 0 })
        {
            foreach (DictionaryEntry entry in exception.Data)
            {
                if (entry.Key is string key
                    && key.StartsWith(AdvancedInformationDataPrefix, StringComparison.Ordinal)
                    && entry.Value is not null
                    && (entry.Value.ToString() ?? string.Empty).Length > 0)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// True if the exception chain has anything worth showing in the Advanced Information
    /// dialog: a stack trace, SQL info, or AdvancedInformation.* entries on any node.
    /// Drives the "Show details" link visibility on the main dialog.
    /// </summary>
    public static bool HasTechnicalDetails(Exception exception)
    {
        if (exception is null) throw new ArgumentNullException(nameof(exception));

        for (Exception? ex = exception; ex is not null; ex = ex.InnerException)
        {
            if (!string.IsNullOrEmpty(ex.StackTrace)) return true;
            if (HasAdditionalData(ex)) return true;
        }
        return false;
    }

    // ---------- helpers ----------

    private static List<(string Key, string Value)> CollectAdvancedInformation(Exception exception)
    {
        var result = new List<(string, string)>();
        if (exception.Data is null || exception.Data.Count == 0) return result;

        foreach (DictionaryEntry entry in exception.Data)
        {
            if (entry.Key is string key
                && key.StartsWith(AdvancedInformationDataPrefix, StringComparison.Ordinal)
                && entry.Value is not null)
            {
                var trimmedKey = key[AdvancedInformationDataPrefix.Length..];
                var value = entry.Value.ToString() ?? string.Empty;
                if (value.Length > 0)
                {
                    result.Add((trimmedKey, value));
                }
            }
        }

        return result;
    }
}
