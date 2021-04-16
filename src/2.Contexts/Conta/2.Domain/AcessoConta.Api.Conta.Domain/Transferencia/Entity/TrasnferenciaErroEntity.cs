using System;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Entity
{
    public class TrasnferenciaErroEntity
    {

        public TrasnferenciaErroEntity()
        { }

        public int Id { get; protected set; }
        public Guid? IdTransferencia { get; protected set; }
        public string DescricaoErro { get; protected set; }

        public virtual void AtribuirIdTransferencia(Guid? idTrasferencia)
        {
            IdTransferencia = idTrasferencia;
        }
    }
}