// Fake exception type whose FullName matches the real SqlClient exception, so the
// reflection-based SqlExceptionInfo detects it. No actual SqlClient dependency.

namespace Microsoft.Data.SqlClient
{
    internal sealed class SqlException : System.Exception
    {
        public SqlException(string message) : base(message) { }
        public int Number { get; init; }
        public byte Class { get; init; }
        public byte State { get; init; }
        public int LineNumber { get; init; }
        public string? Procedure { get; init; }
        public string? Server { get; init; }
    }
}
