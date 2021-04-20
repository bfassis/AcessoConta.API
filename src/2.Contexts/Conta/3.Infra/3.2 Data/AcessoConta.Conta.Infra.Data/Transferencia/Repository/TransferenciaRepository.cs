using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Repositoty;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Api.Conta.Domain.Transferencia.ReadModel;
using AcessoConta.Api.Core.Orm.Dapper.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<TransferenciaReadModel> ConsultarTrasnferencia(string transactionId) => await _dapper.ExecuteQueryAsync(async connection =>
        {
            var query = @"
							SELECT 
							   T.ID	AS Id
							  ,T.ID_TRANSACAO AS IdTransferencia
							  ,T.STATUS AS StatusTrasferencia
							  ,TE.ID AS Id
							  ,TE.ID_TRANSACAO AS IdTransferencia
							  ,TE.DSC_ERRO AS DescricaoErro
						   FROM TRANSFERENCIA T
						   LEFT JOIN TRANSFERENCIA_ERRO TE ON TE.ID_TRANSACAO = T.ID_TRANSACAO
						   WHERE T.ID_TRANSACAO = @transactionId
                           ORDER BY T.STATUS desc

						";

            var retorno = await connection.QueryAsync<TransferenciaReadModel, TrasnferenciaErroReadModel, TransferenciaReadModel>(
                sql: query,
                param: new { transactionId },
                map: (trasnferencia, transferenciaErro) =>
                {
                    trasnferencia.TrasnferenciaErroReadModel = transferenciaErro;

                    return trasnferencia;
                }
                );

            return retorno?.FirstOrDefault();
        });

        public async Task InserirTransferencia(TransferenciaEntity entity) => await _dapper.ExecuteQueryAsync(async connection =>
        {
            //var chaveTransancao = entity.GerarIdTransferencia();

            var query = @"
                            INSERT INTO [dbo].[TRANSFERENCIA]
                                       ([CONTA]
                                       ,[VALOR_TRASFERENCIA]
                                       ,[ID_TRANSACAO]
                                       ,[STATUS]
                                       ,[TIPO_TRANSACAO]
                                       ,[DATA_TRANSACAO])
                                 VALUES
                                       (@Conta,
										@Valor,
										@IdTransferencia,
										@StatusTrasferencia,
										@TipoTransacao,
										@DataTransferencia)
							";

            return await connection.QueryFirstOrDefaultAsync(sql: query, param: new
            {
                entity.Conta,
                @Valor = entity.Valor.ToString(),
                @IdTransferencia = entity.IdTransferencia,
                entity.StatusTrasferencia,
                entity.TipoTransacao,
                entity.DataTransferencia
            });

        });

        public async Task InserirTransferenciaErro(TransferenciaErroEntity entity) => await _dapper.ExecuteQueryAsync(async connection =>
        {
            var query = @"
                            INSERT INTO [dbo].[TRANSFERENCIA_ERRO]
                                       ([ID_TRANSACAO]
                                       ,[DSC_ERRO])
                                 VALUES
                                       (@IdTransferencia
                                       ,@DescricaoErro)
							";

            return await connection.QueryFirstOrDefaultAsync(sql: query, param: new
            {
                entity.IdTransferencia,
                entity.DescricaoErro
            });

        });
    }
}
