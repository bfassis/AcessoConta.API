using AcessoConta.Api.Common.Enums.Transacao;
using AcessoConta.Api.Common.Validators;
using AcessoConta.Api.Conta.Domain.Transferencia.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Entity
{
    public class TransferenciaEntity : ValidatorBase
    {
        public Guid IdTransferencia { get; protected set; }
        public virtual string ContaOrigem { get; protected set; }
        public virtual string ContaDestino { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public ETipoTransacao TipoTransacao { get; protected set; }
        public EStatusTransferencia StatusTrasferencia { get; protected set; }
        public DateTime DataTransferencia { get; protected set; }

        public TransferenciaEntity()
        {
            TipoTransacao = ETipoTransacao.Credito;
            StatusTrasferencia = EStatusTransferencia.Sucesso;
        }

        public TransferenciaEntity(string contaOrigem, string contaDestino, decimal valor, ETipoTransacao tipoTransacao, EStatusTransferencia statusTransferencia)
        {
            IdTransferencia = Guid.NewGuid();
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
            TipoTransacao = tipoTransacao;
            StatusTrasferencia = statusTransferencia;
            DataTransferencia = DateTime.Now;

            Validate(this, new TransferenciaValidator());
        }

        public virtual Guid GerarIdTransferencia()
        {
           return IdTransferencia = Guid.NewGuid();
        }

        public virtual void AtribuirTipoTransacao(ETipoTransacao eTipoTransacao)
        {
            TipoTransacao = eTipoTransacao;        
        }

        public virtual void AtribuirStatusTransferencia(EStatusTransferencia eStatusTransferencia)
        {
            StatusTrasferencia = eStatusTransferencia;
        }


        public virtual void Validate(TransferenciaEntity entity)
        {
            Validate(entity, new TransferenciaValidator());
        }

    }
}
