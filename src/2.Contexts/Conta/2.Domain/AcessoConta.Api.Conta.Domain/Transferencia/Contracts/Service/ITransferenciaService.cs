using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Api.Conta.Domain.Transferencia.ReadModel;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service
{
    public interface ITransferenciaService
    {
        Task<string> Transferir(TransferenciaDebitoEntity transferenciaDebitoEntity, TrasnferenciaCreditoEntity trasnferenciaCreditoEntity);
        Task<bool> ContasExistentes(TransferenciaEntity transferenciaEntity);
        Task<BalanceAdjustmentResponse> ValidarConta(string accountNumber);
        Task<TransferenciaReadModel> ConsultarTrasnferencia(string transactionId);
        Task InserirTransferencia(TransferenciaEntity entity);
    }
}
