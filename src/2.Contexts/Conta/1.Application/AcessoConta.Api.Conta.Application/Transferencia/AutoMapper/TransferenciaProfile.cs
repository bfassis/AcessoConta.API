using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.AutoMapper
{
    public class TransferenciaProfile : Profile
    {
        public TransferenciaProfile()
        {
            CreateMap<TransferRequest, TransferenciaEntity>()
                    .ForMember(dest => dest.ContaDestino, opt => opt.MapFrom(src => src.AccountDestination))
                    .ForMember(dest => dest.ContaOrigem, opt => opt.MapFrom(src => src.AccountOrigin))
                    .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Value));

            CreateMap<TransferenciaEntity, TransferResponse>()
                   .ForMember(dest => dest.transactionId, opt => opt.MapFrom(src => src.IdTransferencia));
        }
    }
}
