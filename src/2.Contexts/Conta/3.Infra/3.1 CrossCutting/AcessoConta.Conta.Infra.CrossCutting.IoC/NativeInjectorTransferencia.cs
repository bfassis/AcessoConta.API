using AcessoConta.Api.Conta.Application.Transferencia.AutoMapper;
using AcessoConta.Api.Conta.Application.Transferencia.Contract;
using AcessoConta.Api.Conta.Application.Transferencia.Facade;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Repositoty;
using AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Service;
using AcessoConta.Api.Conta.Domain.Transferencia.Service;
using AcessoConta.Conta.Infra.Data.Transferencia.Repository;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AcessoConta.Conta.Infra.CrossCutting.IoC
{
    public class NativeInjectorTransferencia
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterAutoMapper(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            services.AddScoped<ITransferenciaService, TransferenciaService>();
            services.AddScoped<ITransferenciaFacade, TransferenciaFacade>();
         
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new TransferenciaProfile());
            });
        }
    }
}
