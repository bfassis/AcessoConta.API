using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response
{
    public class BalanceAdjustmentResponse : BaseResponse
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }


        public virtual void Validate(BalanceAdjustmentResponse response)
        {
            Validate(response, new BalanceAdjustmentValidator());
        }
    }
}
