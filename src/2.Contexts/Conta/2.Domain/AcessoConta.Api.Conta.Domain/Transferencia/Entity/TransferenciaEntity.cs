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
        public int Id { get; protected set; }
        public Guid? IdTransferencia { get; protected set; }
        public virtual string ContaOrigem { get; protected set; }
        public virtual string ContaDestino { get; protected set; }
        public virtual string Conta { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public ETipoTransacao TipoTransacao { get; protected set; }
        public EStatusTransferencia StatusTrasferencia { get; protected set; }
        public DateTime DataTransferencia { get; protected set; }
        public TrasnferenciaErroEntity TrasnferenciaErroEntity { get; protected set; }

        public TransferenciaEntity()
        {
            TrasnferenciaErroEntity = new TrasnferenciaErroEntity();
            DataTransferencia = DateTime.Now;
            //GerarIdTransferencia();
            TrasnferenciaErroEntity.AtribuirIdTransferencia(IdTransferencia);

        }

        public TransferenciaEntity(string conta, string contaOrigem, string contaDestino, decimal valor, ETipoTransacao tipoTransacao, EStatusTransferencia statusTransferencia)
        {
            Conta = conta;
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
            if (IdTransferencia == null)
            {
                IdTransferencia = Guid.NewGuid();
                TrasnferenciaErroEntity.AtribuirIdTransferencia(IdTransferencia);
            }

            return (Guid)IdTransferencia;
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

        public virtual void AtribuirTransferenciaErro(TrasnferenciaErroEntity trasnferenciaErroEntity)
        {
            TrasnferenciaErroEntity = trasnferenciaErroEntity;
        }
    }

   
}
