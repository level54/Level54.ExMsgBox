using System;
using System.Globalization;
using System.Reflection;

namespace Level54.ExMsgBox.Internal;

/// <summary>
/// Reflection-only wrapper that surfaces SQL Server exception details without
/// taking any compile-time reference to Microsoft.Data.SqlClient or System.Data.SqlClient.
/// </summary>
internal sealed class SqlExceptionInfo
{
    private const string MicrosoftSqlClientFullName = "Microsoft.Data.SqlClient.SqlException";
    private const string SystemSqlClientFullName = "System.Data.SqlClient.SqlException";

    private readonly Exception _exception;

    public SqlExceptionInfo(Exception exception)
    {
        _exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    public bool IsSqlException
    {
        get
        {
            var fullName = _exception.GetType().FullName;
            return fullName is MicrosoftSqlClientFullName or SystemSqlClientFullName;
        }
    }

    public int Number => ReadStruct<int>(nameof(Number));
    public byte Class => ReadStruct<byte>(nameof(Class));
    public byte State => ReadStruct<byte>(nameof(State));
    public int LineNumber => ReadStruct<int>(nameof(LineNumber));
    public string? Procedure => ReadClass<string>(nameof(Procedure));
    public string? Server => ReadClass<string>(nameof(Server));

    private T ReadStruct<T>(string memberName) where T : struct
    {
        var property = GetProperty(memberName);
        if (property is null) return default;
        try
        {
            var raw = property.GetValue(_exception);
            if (raw is null) return default;
            return (T)Convert.ChangeType(raw, typeof(T), CultureInfo.InvariantCulture);
        }
        catch
        {
            return default;
        }
    }

    private T? ReadClass<T>(string memberName) where T : class
    {
        var property = GetProperty(memberName);
        if (property is null) return null;
        try
        {
            return property.GetValue(_exception) as T;
        }
        catch
        {
            return null;
        }
    }

    private PropertyInfo? GetProperty(string memberName) =>
        _exception.GetType().GetProperty(
            memberName,
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
}
