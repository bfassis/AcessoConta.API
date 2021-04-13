using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Application.Transferencia.Contract
{
    public interface ITransferenciaFacade
    {
        Task<TransferResponse> Trasnferir(TransferRequest request);
    }
}
