using AcessoConta.Api.Common.Enums.Transacao;
using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Conta.Application.Transferencia.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Messages.Response
{
    public class TrasactionResponse : BaseResponse
    {
        public TrasactionResponse()
        {
            Data = new TrasactionDto();
        }

        public TrasactionDto Data { get; set; }
    }
}
