using AcessoConta.Api.Common.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response
{
    public class ListBalanceAdjustmentResponse : BaseResponse
    {
        public IEnumerable<BalanceAdjustmentResponse> BalanceAdjustmentResponses { get; set; }
    }
}
