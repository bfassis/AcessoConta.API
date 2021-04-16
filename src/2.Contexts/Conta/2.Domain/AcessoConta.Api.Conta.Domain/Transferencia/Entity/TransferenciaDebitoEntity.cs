using AcessoConta.Api.Common.Enums.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Entity
{
    public class TransferenciaDebitoEntity : TransferenciaEntity
    {

        public TransferenciaDebitoEntity()
        {
            TipoTransacao = ETipoTransacao.Debito;
            StatusTrasferencia = EStatusTransferencia.Confirmado;
        }
    }
}
