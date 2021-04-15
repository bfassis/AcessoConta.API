using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Conta.Application.Transferencia.Contract;
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

        public async Task<TransferResponse> Trasnferir(TransferRequest request)
        {
            try
            {
                TransferResponse response = new TransferResponse();

                var transferenciaEntity = _mapper.Map<TransferenciaEntity>(request);

                transferenciaEntity.Validate(transferenciaEntity);

                if (!transferenciaEntity.Valid)
                {
                    _notification.AddNotifications(transferenciaEntity.ValidationResult);
                    return response;
                }

                await _transferenciaService.Transferir(transferenciaEntity);

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
