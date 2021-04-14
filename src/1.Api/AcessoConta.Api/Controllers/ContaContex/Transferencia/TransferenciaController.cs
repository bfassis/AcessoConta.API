using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Application.Transferencia.Contract;
using AcessoConta.Api.Conta.Application.Transferencia.Facade;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcessoConta.Api.Controllers.ContaContex.Transferencia
{
    [Route("api/conta/transferencia")]
    [ApiController]
    public class TransferenciaController : BaseController
    {
        private readonly ITransferenciaFacade _transferenciaFacade;


        public TransferenciaController(INotification notification ,ITransferenciaFacade transferenciaFacade ) : base(notification)
        {
            _transferenciaFacade = transferenciaFacade;
        }

        [HttpPost()]
        public async Task<ActionResult<TransferResponse>> Post(TransferRequest request)
        {
            var result = await _transferenciaFacade.Trasnferir(request);
            return Response(result);
        }
    }
}
