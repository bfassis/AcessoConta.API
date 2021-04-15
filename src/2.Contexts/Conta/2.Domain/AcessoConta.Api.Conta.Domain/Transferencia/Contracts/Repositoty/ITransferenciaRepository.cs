﻿using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Contracts.Repositoty
{
    public interface ITransferenciaRepository
    {
        Task InserirTransferencia(TransferenciaEntity entity);
    }
}
