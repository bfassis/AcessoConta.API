using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Conta.Application.Transferencia.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Messages.Response
{
    public class TransferResponse : BaseResponse
    {
        public TransferenciaDto Data { get; set; }
    }
}
