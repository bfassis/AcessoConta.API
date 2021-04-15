using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Request;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Contract
{
    public interface IAccountHttpClient
    {
        Task<ListBalanceAdjustmentResponse> ObterAccounts();
        Task<BalanceAdjustmentResponse> ObterAccountPorAccount(string account);
        Task<AccountResponse> InserirTrasactionAccount(AccountRequest accountRequest);
    }
}
