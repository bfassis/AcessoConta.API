using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Repositoty;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Contract;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Request;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response;
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
        private readonly ITransferenciaRepository _transferenciaRepository;

        public TransferenciaService(IAccountHttpClient accountHttpClient, INotification notification, ITransferenciaRepository transferenciaRepository)
        {
            _accountHttpClient = accountHttpClient;
#pragma warning disable CS1717 // Assignment made to same variable
            _notification = notification;
#pragma warning restore CS1717 // Assignment made to same variable
            _transferenciaRepository = transferenciaRepository;
        }

        public async Task<bool> ContasExistentes(TransferenciaEntity transferenciaEntity)
        {
            var accounts = await _accountHttpClient.ObterAccounts();

            if (accounts.BalanceAdjustmentResponses.Select(x => x.AccountNumber == transferenciaEntity.ContaOrigem && x.AccountNumber == transferenciaEntity.ContaDestino).Count() == 2)
                return true;

            return false;
        }

        public async Task<BalanceAdjustmentResponse> ValidarConta(string accountNumber)
        {
            var account = await _accountHttpClient.ObterAccountPorAccount(accountNumber);

            return account;
        }



        public async Task Transferir(TransferenciaEntity transferenciaEntity)
        {
            if ((await Debito(transferenciaEntity)).Success)
            {
                if (!(await Credito(transferenciaEntity)).Success)
                {
                    if (!(await EstornoCredito(transferenciaEntity)).Success)
                    {
                        _notification.AddNotification("Conta", "Problema a fazer o estorno.");
                    }
                }
            }

        }

        private async Task<AccountResponse> Debito(TransferenciaEntity transferenciaEntity)
        {
            var account = await ValidarConta(transferenciaEntity.ContaOrigem);
            var accountResponse = new AccountResponse();

            account.Validate(account);

            if (!account.Valid)
            {
                _notification.AddNotifications(account.ValidationResult);
                accountResponse.Success = false;
                return accountResponse;
            }

            if (account.Balance < transferenciaEntity.Valor)
            {
                _notification.AddNotification("Conta", "Conta sem saldo para transferencia");
                accountResponse.Success = false;
                return accountResponse;
            }

            var request = new AccountRequest()
            {
                AccountNumber = transferenciaEntity.ContaOrigem,
                Type = Common.Enums.Transacao.AccountTransactionType.Debit,
                Value = transferenciaEntity.Valor
            };


            accountResponse = await _accountHttpClient.InserirTrasactionAccount(request);

            return accountResponse;
        }

        private async Task<AccountResponse> Credito(TransferenciaEntity transferenciaEntity)
        {
            var account = await ValidarConta(transferenciaEntity.ContaDestino);
            var accountResponse = new AccountResponse();

            account.Validate(account);

            if (!account.Valid)
            {
                _notification.AddNotifications(account.ValidationResult);
                accountResponse.Success = false;
                return accountResponse;
            }

            var request = new AccountRequest()
            {
                AccountNumber = transferenciaEntity.ContaDestino,
                Type = Common.Enums.Transacao.AccountTransactionType.Credit,
                Value = transferenciaEntity.Valor
            };

            accountResponse = await _accountHttpClient.InserirTrasactionAccount(request);

            if (!accountResponse.Success)
                transferenciaEntity.AtribuirStatusTransferencia(Common.Enums.Transacao.EStatusTransferencia.Erro);

            await _transferenciaRepository.InserirTransferencia(transferenciaEntity);

            return accountResponse;
        }

        private async Task<AccountResponse> EstornoCredito(TransferenciaEntity transferenciaEntity)
        {
            var account = await ValidarConta(transferenciaEntity.ContaDestino);
            var accountResponse = new AccountResponse();

            account.Validate(account);

            if (!account.Valid)
            {
                _notification.AddNotifications(account.ValidationResult);
                accountResponse.Success = false;
                return accountResponse;
            }

            var request = new AccountRequest()
            {
                AccountNumber = transferenciaEntity.ContaOrigem,
                Type = Common.Enums.Transacao.AccountTransactionType.Credit,
                Value = transferenciaEntity.Valor
            };

            accountResponse = await _accountHttpClient.InserirTrasactionAccount(request);

            if (!accountResponse.Success)
                transferenciaEntity.AtribuirStatusTransferencia(Common.Enums.Transacao.EStatusTransferencia.Erro);

            await _transferenciaRepository.InserirTransferencia(transferenciaEntity);

            return accountResponse;
        }
    }
}
