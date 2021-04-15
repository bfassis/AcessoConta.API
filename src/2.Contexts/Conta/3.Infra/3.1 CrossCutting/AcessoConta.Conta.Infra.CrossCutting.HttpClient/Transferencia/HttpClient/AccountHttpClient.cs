using AcessoConta.Api.Common.HttpClient;
using AcessoConta.Api.Common.HttpClient.Utils;
using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Common.Notifications;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Contract;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Request;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.HttpClient
{
    public class AccountHttpClient : HttpClientBase, IAccountHttpClient
    {
        private readonly INotification _notification;

        public AccountHttpClient(IHttpClientFactory httpClientFactory, INotification notification) : base(httpClientFactory.CreateClient("AcessoApi"))
        {
            _notification = notification;
        }

        public async Task<AccountResponse> InserirTrasactionAccount(AccountRequest accountRequest)
        {
            var response = new AccountResponse();

            var resposta = await PostAsJsonAsync($"{"Account/"}", new JsonContent(accountRequest));
            if (!resposta.IsSuccessStatusCode)
            {
                _notification.AddNotification("Erro", "Operação nao efetuada.");
                response.Success = false;
                return response;
            }

            return response;
        }

        public async Task<BalanceAdjustmentResponse> ObterAccountPorAccount(string account)
        {
            var response = new BalanceAdjustmentResponse();

            var resposta = await GetAsJsonAsync($"{"Account/"}{account}");
            if (!resposta.IsSuccessStatusCode)
            {
                _notification.AddNotification("Erro", "Account Api.");
                response.Success = false;
                return response;
            }
            response = JsonConvert.DeserializeObject<BalanceAdjustmentResponse>(resposta.Content.ReadAsStringAsync().Result);
            return response;

        }

        public async Task<ListBalanceAdjustmentResponse> ObterAccounts()
        {
            var response = new ListBalanceAdjustmentResponse();

            var resposta = await GetAsJsonAsync($"{"Account"}");

            if (!resposta.IsSuccessStatusCode)
            {
                _notification.AddNotification("Erro", "Account Api.");
                response.Success = false;
                return response;
            }

            response = JsonConvert.DeserializeObject<ListBalanceAdjustmentResponse>(resposta.Content.ReadAsStringAsync().Result);

            return response;
        }
    }
}
