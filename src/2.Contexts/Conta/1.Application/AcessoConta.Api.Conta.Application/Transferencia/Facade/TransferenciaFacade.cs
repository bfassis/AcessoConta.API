using AcessoConta.Api.Conta.Application.Transferencia.Contract;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
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

        public TransferenciaFacade(ITransferenciaService transferenciaService, IMapper mapper)
        {
            _transferenciaService = transferenciaService;
            _mapper = mapper;
        }

        public async Task<TransferResponse> Trasnferir(TransferRequest request)
        {
            try
            {
                var entity = _mapper.Map<TransferenciaEntity>(request);

                var response = new TransferResponse();

                await _transferenciaService.Transferir(entity);

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
