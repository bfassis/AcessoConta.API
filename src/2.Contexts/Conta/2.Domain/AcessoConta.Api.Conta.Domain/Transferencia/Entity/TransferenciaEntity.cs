using AcessoConta.Api.Common.Enums.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Entity
{
    public class TransferenciaEntity
    {
        public Guid IdTransferencia { get; protected set; }
        public virtual string ContaOrigem { get; protected set; }
        public virtual string ContaDestino { get; protected set; }
        public virtual float Valor { get; protected set; }
        public ETipoTransacao TipoTransacao { get; protected set; }
        public EStatusTransferencia StatusTrasferencia { get; protected set; }
        public DateTime DataTransferencia { get; protected set; }

        public TransferenciaEntity( string contaOrigem, string contaDestino, float valor, ETipoTransacao tipoTransacao, EStatusTransferencia statusTransferencia )
        {
            IdTransferencia = Guid.NewGuid();
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
            TipoTransacao = tipoTransacao;
            StatusTrasferencia = statusTransferencia;
            DataTransferencia = DateTime.Now;        
        }

    }
}
