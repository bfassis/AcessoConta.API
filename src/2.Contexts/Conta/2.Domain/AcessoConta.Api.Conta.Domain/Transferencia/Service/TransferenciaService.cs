using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Service
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly IAccountHttpClient _accountHttpClient;

        public TransferenciaService(IAccountHttpClient accountHttpClient)
        {
            _accountHttpClient = accountHttpClient;        
        }

        public async Task Transferir(TransferenciaEntity transferenciaEntity)
        {
           var tes =  await _accountHttpClient.ObterAccounts();
        }
    }
}
