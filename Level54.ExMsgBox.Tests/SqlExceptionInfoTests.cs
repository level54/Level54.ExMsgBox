using System;
using FluentAssertions;
using Level54.ExMsgBox.Internal;
using Xunit;

namespace Level54.ExMsgBox.Tests;

public class SqlExceptionInfoTests
{
    [Fact]
    public void IsSqlException_false_for_plain_exception()
    {
        var info = new SqlExceptionInfo(new InvalidOperationException("nope"));
        info.IsSqlException.Should().BeFalse();
    }

    [Fact]
    public void IsSqlException_true_for_microsoft_data_sqlclient_SqlException()
    {
        var ex = new Microsoft.Data.SqlClient.SqlException("boom");
        var info = new SqlExceptionInfo(ex);
        info.IsSqlException.Should().BeTrue();
    }

    [Fact]
    public void IsSqlException_true_for_system_data_sqlclient_SqlException()
    {
        var ex = new System.Data.SqlClient.SqlException("boom");
        var info = new SqlExceptionInfo(ex);
        info.IsSqlException.Should().BeTrue();
    }

    [Fact]
    public void Properties_read_via_reflection_from_microsoft_data_sqlclient()
    {
        var ex = new Microsoft.Data.SqlClient.SqlException("boom")
        {
            Number = 547,
            Class = 16,
            State = 1,
            LineNumber = 42,
            Procedure = "usp_DoStuff",
            Server = "PROD-DB-01"
        };

        var info = new SqlExceptionInfo(ex);

        info.Number.Should().Be(547);
        info.Class.Should().Be(16);
        info.State.Should().Be(1);
        info.LineNumber.Should().Be(42);
        info.Procedure.Should().Be("usp_DoStuff");
        info.Server.Should().Be("PROD-DB-01");
    }

    [Fact]
    public void Properties_read_via_reflection_from_system_data_sqlclient()
    {
        var ex = new System.Data.SqlClient.SqlException("boom")
        {
            Number = 1205,
            Class = 13,
            State = 56,
            LineNumber = 1,
            Procedure = "proc_x",
            Server = "DB"
        };

        var info = new SqlExceptionInfo(ex);

        info.Number.Should().Be(1205);
        info.Class.Should().Be(13);
        info.State.Should().Be(56);
        info.LineNumber.Should().Be(1);
        info.Procedure.Should().Be("proc_x");
        info.Server.Should().Be("DB");
    }

    [Fact]
    public void Properties_default_when_exception_is_not_sql()
    {
        var info = new SqlExceptionInfo(new Exception("plain"));

        info.Number.Should().Be(0);
        info.Class.Should().Be(0);
        info.State.Should().Be(0);
        info.LineNumber.Should().Be(0);
        info.Procedure.Should().BeNull();
        info.Server.Should().BeNull();
    }

    [Fact]
    public void Constructor_rejects_null()
    {
        Action act = () => _ = new SqlExceptionInfo(null!);
        act.Should().Throw<ArgumentNullException>();
    }
}
