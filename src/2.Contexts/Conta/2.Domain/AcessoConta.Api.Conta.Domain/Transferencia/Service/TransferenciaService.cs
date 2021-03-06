using AcessoConta.Api.Common.Messages.Response;
using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Repositoty;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Api.Conta.Domain.Transferencia.ReadModel;
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
            return await _accountHttpClient.ObterAccountPorAccount(accountNumber); 
        }

        public async Task<string> Transferir(TransferenciaDebitoEntity transferenciaDebitoEntity, TrasnferenciaCreditoEntity trasnferenciaCreditoEntity)
        {
            var trasnferenciaID = Guid.NewGuid();

            if ((await ExecutarTrasferencia(trasnferenciaID,transferenciaDebitoEntity)).Success)
            {
                if (!(await ExecutarTrasferencia(trasnferenciaID ,trasnferenciaCreditoEntity)).Success)
                {
                    await ExecutarTrasferenciaEstorno(transferenciaDebitoEntity);
                }
            }

            return transferenciaDebitoEntity.IdTransferencia.ToString();
        }

        private async Task<AccountResponse> ExecutarTrasferencia(Guid trasnferenciaID, TransferenciaEntity transferenciaEntity)
        {
            _notification.ClearNotifications();
            var accountResponse = new AccountResponse();

            var account = await ValidarConta(transferenciaEntity.Conta);

            account.Validate(account);

            if (!account.Valid)
            {
                _notification.AddNotifications(account.ValidationResult);
                accountResponse.Success = false;
            }

            if (transferenciaEntity.TipoTransacao == Common.Enums.Transacao.ETipoTransacao.Debito)
            {
                if (account.Balance < transferenciaEntity.Valor)
                {
                    _notification.AddNotification("Conta", "Conta sem saldo para transferencia");
                    accountResponse.Success = false;
                }
            }

            if (!_notification.HasNotifications)
            {
                var request = new AccountRequest()
                {
                    AccountNumber = transferenciaEntity.Conta,
                    Type = transferenciaEntity.TipoTransacao == Common.Enums.Transacao.ETipoTransacao.Debito ? Common.Enums.Transacao.AccountTransactionType.Debit : Common.Enums.Transacao.AccountTransactionType.Credit,
                    Value = transferenciaEntity.Valor
                };

                accountResponse = await _accountHttpClient.InserirTrasactionAccount(request);
            }

            transferenciaEntity.AtribuirIdTransferencia(trasnferenciaID);
            await InserirTransferencia(transferenciaEntity);

            return accountResponse;
        }

        private async Task<AccountResponse> ExecutarTrasferenciaEstorno(TransferenciaEntity transferenciaEntity)
        {
            _notification.ClearNotifications();
            var accountResponse = new AccountResponse();
            transferenciaEntity.AtribuirTipoTransacao(Common.Enums.Transacao.ETipoTransacao.Estorno);

            var request = new AccountRequest()
            {
                AccountNumber = transferenciaEntity.Conta,
                Type = Common.Enums.Transacao.AccountTransactionType.Credit,
                Value = transferenciaEntity.Valor
            };

            accountResponse = await _accountHttpClient.InserirTrasactionAccount(request);

            if (!accountResponse.Success)
                _notification.AddNotification("Conta", "Problema a fazer o estorno.");


            await InserirTransferencia(transferenciaEntity);

            return accountResponse;
        }



        public async Task<TransferenciaReadModel> ConsultarTrasnferencia(string transactionId)
        {
            return await _transferenciaRepository.ConsultarTrasnferencia(transactionId); ;
        }

        public async Task InserirTransferencia(TransferenciaEntity entity)
        {
            entity.ExisteErro(_notification.HasNotifications);

            await _transferenciaRepository.InserirTransferencia(entity);

            if (_notification.HasNotifications)
            {
                entity.TrasnferenciaErroEntity.AtribuirDescricaoErro(_notification.Notifications.Select(error => error).FirstOrDefault().Message);
                await _transferenciaRepository.InserirTransferenciaErro(entity.TrasnferenciaErroEntity);
            }
        }
    }
}
