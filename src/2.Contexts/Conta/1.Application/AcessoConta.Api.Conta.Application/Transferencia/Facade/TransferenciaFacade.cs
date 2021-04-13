using AcessoConta.Api.Conta.Application.Transferencia.Contract;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Application.Transferencia.Facade
{
    public class TransferenciaFacade : ITransferenciaFacade
    {
        public Task<TransferResponse> Trasnferir(TransferRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
