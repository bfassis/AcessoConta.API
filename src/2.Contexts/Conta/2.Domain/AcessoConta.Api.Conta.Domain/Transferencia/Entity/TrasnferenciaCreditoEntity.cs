using AcessoConta.Api.Common.Enums.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Entity
{
    public class TrasnferenciaCreditoEntity : TransferenciaEntity
    {
        public TrasnferenciaCreditoEntity()
        {
            TipoTransacao = ETipoTransacao.Credito;
            StatusTrasferencia = EStatusTransferencia.Confirmado;
        }
    }
}
