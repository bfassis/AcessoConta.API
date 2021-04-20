using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Application.Transferencia.Contract;
using AcessoConta.Api.Conta.Application.Transferencia.Facade;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AcessoConta.Api.Controllers.ContaContex.Transferencia
{
    [Route("api/conta/transferencia")]
    [ApiController]
    public class TransferenciaController : BaseController
    {
        private readonly ITransferenciaFacade _transferenciaFacade;
        private readonly ILogger<TransferenciaController> _logger;

        public TransferenciaController(INotification notification ,ITransferenciaFacade transferenciaFacade, ILogger<TransferenciaController> logger) : base(notification)
        {
            _transferenciaFacade = transferenciaFacade;
            _logger = logger;
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost()]
        public async Task<ActionResult<TransferResponse>> Post(TransferRequest request)
        {
            _logger.LogInformation($"APIAcesso - POST [REQUEST]:{request}");
            var result = await _transferenciaFacade.Transferir(request);
            return Response(result);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{transactionId}")]
        public async Task<ActionResult<TrasactionResponse>> Get([FromRoute] string transactionId)
        {
            _logger.LogInformation($"APIAcesso - GET :{transactionId}");
            var result = await _transferenciaFacade.ConsultarTrasnferencia(transactionId);
            return Response(result);
        }
    }
}
