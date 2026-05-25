using System;

// Fake exception types matching the FullName of the real SqlClient exceptions.
// SqlExceptionInfo detects SQL exceptions by type FullName + reads properties via reflection,
// so these stand-ins fully exercise the production code paths without any SqlClient dependency.

namespace Microsoft.Data.SqlClient
{
    internal sealed class SqlException : Exception
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

namespace System.Data.SqlClient
{
    internal sealed class SqlException : Exception
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
