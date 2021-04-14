using AcessoConta.Api.Common.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Messages.Response
{
    public class TransferResponse : BaseResponse
    {
        public string transactionId { get; set; }
    }
}
