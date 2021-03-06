using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Application.Transferencia.Contract;
using AcessoConta.Api.Conta.Application.Transferencia.Dto;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Contract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Application.Transferencia.Facade
{
    public class TransferenciaFacade : ITransferenciaFacade
    {
        private readonly ITransferenciaService _transferenciaService;
        private readonly IMapper _mapper;
        private readonly INotification _notification;

        public TransferenciaFacade(ITransferenciaService transferenciaService, IMapper mapper, INotification notification)
        {
            _transferenciaService = transferenciaService;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task<TrasactionResponse> ConsultarTrasnferencia(string transactionId)
        {
            TrasactionResponse response = new TrasactionResponse();

            if(string.IsNullOrEmpty(transactionId))
            {
                _notification.AddNotification("Erro", "O campo transactionId é obrigatorio");
                return response;
            }
            
            var resutadoTransferencia = await _transferenciaService.ConsultarTrasnferencia(transactionId);

            if (resutadoTransferencia == null)
            {
                _notification.AddNotification("Erro", "Transferencia não encontrada.");
                return response;
            }

            response.Data = _mapper.Map<TrasactionDto>(resutadoTransferencia);

            return response;
        }

        public async Task<TransferResponse> Transferir(TransferRequest request)
        {
            try
            {
                TransferResponse response = new TransferResponse();

                var transferenciaDebitoEntity = _mapper.Map<TransferenciaDebitoEntity>(request);
                var transferenciaCreditoEntity = _mapper.Map<TrasnferenciaCreditoEntity>(request);

                transferenciaDebitoEntity.Validate(transferenciaDebitoEntity);
                transferenciaCreditoEntity.Validate(transferenciaCreditoEntity);

                if (!(transferenciaDebitoEntity.Valid || transferenciaCreditoEntity.Valid))
                {
                    _notification.AddNotifications(transferenciaDebitoEntity.ValidationResult);
                    _notification.AddNotifications(transferenciaCreditoEntity.ValidationResult);
                    return response;
                }

                response.Data.TransactionId = await _transferenciaService.Transferir(transferenciaDebitoEntity, transferenciaCreditoEntity);

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
