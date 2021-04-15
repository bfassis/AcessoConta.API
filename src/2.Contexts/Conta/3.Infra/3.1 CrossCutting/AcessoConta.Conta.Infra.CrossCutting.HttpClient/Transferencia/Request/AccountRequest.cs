using AcessoConta.Api.Common.Enums.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Request
{
    public class AccountRequest
    {
        public string AccountNumber { get; set; }
        public decimal Value { get; set; }
        public AccountTransactionType Type { get; set; }

    }
}
