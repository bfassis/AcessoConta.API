using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
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
        Task<bool> ValidarSaldoConta(string accountNumber);
    }
}
