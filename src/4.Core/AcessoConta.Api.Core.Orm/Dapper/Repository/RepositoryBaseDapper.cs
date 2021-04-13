using AcessoConta.Api.Core.Orm.Dapper.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Core.Orm.Dapper.Repository
{

    public sealed class RepositoryBaseDapper<TContext> : IDisposable
where TContext : IDatabaseContextDapper
    {
        private readonly TContext _context;

        public RepositoryBaseDapper(TContext context)
        {
            _context = context;
        }

        private IDbTransaction BeginTransaction()
        {
            return _context.GetConnection().BeginTransaction();
        }

        public async Task<Out> ExecuteQueryAsync<Out>(System.Func<IDbConnection, Task<Out>> func)
        {
            try
            {
                return await func(_context.GetConnection());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Out> ExecuteTransactionAsync<Out>(System.Func<IDbTransaction, Task<Out>> func)
        {
            IDbTransaction transaction = null;

            try
            {
                return await func(transaction = this.BeginTransaction());
            }
            catch (Exception ex)
            {

                if (transaction != null)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (transaction != null)
                    transaction.Dispose();
            }
        }

        public void Dispose()
        {
        }
    }

}
