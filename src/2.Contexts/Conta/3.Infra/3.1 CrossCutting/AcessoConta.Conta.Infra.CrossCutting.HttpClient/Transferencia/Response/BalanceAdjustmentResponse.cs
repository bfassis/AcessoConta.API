using AcessoConta.Api.Common.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response
{
    public class BalanceAdjustmentResponse : BaseResponse
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public float Value { get; set; }
    }
}
