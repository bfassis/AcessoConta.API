using AcessoConta.Api.Common.Enums.Notification;
using AcessoConta.Api.Common.HttpClient.Response;
using AcessoConta.Api.Common.HttpClient.Utils;
using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Common.Notifications;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Common.HttpClient
{
    public abstract class HttpClientBase
    {
        private readonly System.Net.Http.HttpClient _httpClient;       

        public HttpClientBase(System.Net.Http.HttpClient httpClient)
        {
            this._httpClient = httpClient;          
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync(string url, JsonContent content)
        {
            return await _httpClient.PostAsync(url, content);
        }


        public async Task<HttpResponseMessage> GetAsJsonAsync(string url)       
        {
            return await _httpClient.GetAsync(url);
        }



    }
}
