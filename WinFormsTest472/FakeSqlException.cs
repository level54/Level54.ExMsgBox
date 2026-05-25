// Fake type whose FullName matches the real Microsoft.Data.SqlClient.SqlException so the
// Microsoft.ExceptionMessageBox dialog (which detects SQL exceptions by FullName via
// reflection) will treat it as a real SqlException and render the SQL details panel.
// No actual Microsoft.Data.SqlClient dependency is needed.

namespace Microsoft.Data.SqlClient
{
    public sealed class SqlException : System.Exception
    {
        public SqlException(string message) : base(message) { }

        public int Number { get; set; }
        public byte Class { get; set; }
        public byte State { get; set; }
        public int LineNumber { get; set; }
        public string Procedure { get; set; }
        public string Server { get; set; }
    }
}
