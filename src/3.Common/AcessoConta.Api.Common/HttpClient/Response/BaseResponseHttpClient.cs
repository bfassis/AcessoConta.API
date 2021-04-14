using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AcessoConta.Api.Common.HttpClient.Response
{
    public class BaseResponseHttpClient
    {
        public bool IsSuccessStatusCode { get; set; }
        public HttpStatusCode Status { get; set; }
        public HttpContent Content { get; set; }
    }
}
