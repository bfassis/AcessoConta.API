using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Repositoty;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Api.Core.Orm.Dapper.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Conta.Infra.Data.Transferencia.Repository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
		private readonly RepositoryBaseDapper<AcessoContaDataBaseContextDapper> _dapper;

		public TransferenciaRepository(RepositoryBaseDapper<AcessoContaDataBaseContextDapper> dapper)
		{
			_dapper = dapper;
		}

		public async Task InserirTransferencia(TransferenciaEntity entity) => await _dapper.ExecuteQueryAsync(async connection =>
		{
			var query = @"
                            INSERT INTO [dbo].[TRANSFERENCIA]
                                       ([CONTA_ORIGEM]
                                       ,[CONTA_DESTINO]
                                       ,[VALOR_TRASFERENCIA]
                                       ,[ID_TRANSACAO]
                                       ,[STATUS]
                                       ,[TIPO_TRANSACAO]
                                       ,[DATA_TRANSACAO])
                                 VALUES
                                       (@ContaOrigem,
										@ContaDestino,
										@Valor,
										@IdTransferencia,
										@StatusTrasferencia,
										@TipoTransacao,
										@DataTransferencia)
							";

			return await connection.QueryFirstOrDefaultAsync(sql: query, param: new
			{
				entity.ContaOrigem,
				entity.ContaDestino,
				entity.Valor,
				@IdTransferencia = entity.GerarIdTransferencia(),
				entity.StatusTrasferencia,
				entity.TipoTransacao,
				@DataTransferencia = DateTime.Now
			});
		});
	}
}
