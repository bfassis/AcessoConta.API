using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcessoConta.Api.Core.Orm.Dapper.Contract
{
    public interface IDatabaseContextDapper : IDisposable
    {
        IDbConnection GetConnection();
    }
}
