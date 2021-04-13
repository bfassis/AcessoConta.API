using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Messages.Request
{
    public class TransferRequest
    {
        public string AccountOrigin { get; set; }
        public string AccountDestination { get; set; }
        public float Value { get; set; }

    }
}
