using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service
{
    public interface ITransferenciaService
    {
        Task Transferir(TransferenciaEntity transferenciaEntity);
        Task<bool> ContasExistentes(TransferenciaEntity transferenciaEntity);
        Task<BalanceAdjustmentResponse> ValidarConta(string accountNumber);
    }
}
