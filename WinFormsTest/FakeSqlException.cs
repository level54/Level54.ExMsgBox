// Fake type whose FullName matches the real Microsoft.Data.SqlClient.SqlException so
// Level54.ExMsgBox's reflection-based SqlExceptionInfo will treat it as a SqlException
// and render the SQL details panel — without any Microsoft.Data.SqlClient dependency.

namespace Microsoft.Data.SqlClient
{
    public sealed class SqlException : System.Exception
    {
        public SqlException(string message) : base(message) { }

        public int Number { get; set; }
        public byte Class { get; set; }
        public byte State { get; set; }
        public int LineNumber { get; set; }
        public string? Procedure { get; set; }
        public string? Server { get; set; }
    }
}
