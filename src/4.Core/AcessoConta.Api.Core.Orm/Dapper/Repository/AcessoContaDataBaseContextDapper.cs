using AcessoConta.Api.Core.Orm.Dapper.Contract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AcessoConta.Api.Core.Orm.Dapper.Repository
{

    public class AcessoContaDataBaseContextDapper : IDatabaseContextDapper
    {
        private readonly Dictionary<string, IDbConnection> _connections;

        private readonly string _connectionString;

        public AcessoContaDataBaseContextDapper(IConfiguration configuration)
        {
            _connections = new Dictionary<string, IDbConnection>();

            _connectionString = configuration.GetSection("ConnectionStrings:AcessoContaDB").Value;
        }

        public IDbConnection GetConnection()
        {
            if (!_connections.ContainsKey(_connectionString))
            {
                _connections.Add(_connectionString, new SqlConnection(_connectionString));
                _connections[_connectionString].Open();
            }
            else
            {
                if (_connections[_connectionString].State != ConnectionState.Open)
                {
                    _connections[_connectionString].Open();
                }
            }

            return _connections[_connectionString];
        }

        public void Dispose()
        {
            foreach (var connection in _connections)
            {
                if (connection.Value != null)
                {
                    connection.Value.Dispose();
                }
            }
        }
    }

}
