using AcessoConta.Api.Conta.Application.Transferencia.Dto;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Request;
using AcessoConta.Api.Conta.Application.Transferencia.Messages.Response;
using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using AcessoConta.Api.Conta.Domain.Transferencia.ReadModel;
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

            CreateMap<TransferenciaEntity, TransferRequest>()
                   .ForMember(dest => dest.AccountDestination, opt => opt.MapFrom(src => src.ContaDestino))
                   .ForMember(dest => dest.AccountOrigin, opt => opt.MapFrom(src => src.ContaOrigem))
                   .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Valor));

            CreateMap<TransferenciaEntity, TransferenciaDto>()
                   .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.IdTransferencia));

            CreateMap<TransferRequest, TransferenciaDebitoEntity>()
                    .ForMember(dest => dest.Conta, opt => opt.MapFrom(src => src.AccountOrigin))
                    .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Value));

            CreateMap<TransferRequest, TrasnferenciaCreditoEntity>()
                    .ForMember(dest => dest.Conta, opt => opt.MapFrom(src => src.AccountDestination))
                    .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Value));

            CreateMap<TransferenciaReadModel, TrasactionDto>()
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusTrasferencia.ToString()))
                   .ForMember(dest => dest.transactionId, opt => opt.MapFrom(src => src.IdTransferencia))
                   .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.TrasnferenciaErroReadModel.DescricaoErro));
        }
    }
}
