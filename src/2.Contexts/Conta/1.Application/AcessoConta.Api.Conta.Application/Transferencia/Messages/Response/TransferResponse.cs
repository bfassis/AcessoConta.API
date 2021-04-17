using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Conta.Application.Transferencia.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Messages.Response
{
    public class TransferResponse : BaseResponse
    {
        public TransferResponse()
        {
            Data = new TransferenciaDto();
        }
        public TransferenciaDto Data { get; set; }
    }
}
