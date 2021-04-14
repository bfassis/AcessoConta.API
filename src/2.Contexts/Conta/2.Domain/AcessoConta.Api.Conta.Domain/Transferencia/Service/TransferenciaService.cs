using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Service
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly IAccountHttpClient _accountHttpClient;
        private readonly INotification _notification;

        public TransferenciaService(IAccountHttpClient accountHttpClient, INotification notification)
        {
            _accountHttpClient = accountHttpClient;
#pragma warning disable CS1717 // Assignment made to same variable
            _notification = notification;
#pragma warning restore CS1717 // Assignment made to same variable
        }

        public async Task<bool> ContasExistentes(TransferenciaEntity transferenciaEntity)
        {
            var accounts = await _accountHttpClient.ObterAccounts();

            if (accounts.Select(x => x.AccountNumber == transferenciaEntity.ContaOrigem && x.AccountNumber == transferenciaEntity.ContaDestino).Count() == 2)
                return true;

            return false;
        }

        public async Task<bool> ValidarSaldoConta(string accountNumber)
        {
            var account = await _accountHttpClient.ObterAccountPorAccount(accountNumber);

            account.Validate(account);

            if (!account.Valid)
            {
                _notification.AddNotifications(account.ValidationResult);
                return false;
            }

            return true;
        }



        public async Task Transferir(TransferenciaEntity transferenciaEntity)
        {

            await ValidarSaldoConta(transferenciaEntity.ContaOrigem);

        }
    }
}
