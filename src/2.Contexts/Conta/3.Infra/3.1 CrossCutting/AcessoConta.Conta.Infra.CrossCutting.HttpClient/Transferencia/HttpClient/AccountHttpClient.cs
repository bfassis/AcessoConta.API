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

        public async Task<BaseResponse> InserirTrasactionAccount(AccountRequest accountRequest)
        {

            var resposta = await PostAsJsonAsync($"{"Account/"}",new JsonContent(accountRequest));
            if (!resposta.IsSuccessStatusCode)
                _notification.AddNotification("Erro", "Account Api.");

            return JsonConvert.DeserializeObject<BaseResponse>(resposta.Content.ReadAsStringAsync().Result);
        }

        public async Task<BalanceAdjustmentResponse> ObterAccountPorAccount(string account)
        {
            var resposta = await GetAsJsonAsync($"{"Account/"}{account}");
            if (!resposta.IsSuccessStatusCode)
                _notification.AddNotification("Erro", "Account Api.");

            return JsonConvert.DeserializeObject<BalanceAdjustmentResponse>(resposta.Content.ReadAsStringAsync().Result);

        }

        public async Task<IEnumerable<BalanceAdjustmentResponse>> ObterAccounts()
        {
            var resposta = await GetAsJsonAsync($"{"Account"}");
            if (!resposta.IsSuccessStatusCode)
                _notification.AddNotification("Erro", "Account Api.");

            return JsonConvert.DeserializeObject<IEnumerable<BalanceAdjustmentResponse>>(resposta.Content.ReadAsStringAsync().Result);
        }

    }
}
