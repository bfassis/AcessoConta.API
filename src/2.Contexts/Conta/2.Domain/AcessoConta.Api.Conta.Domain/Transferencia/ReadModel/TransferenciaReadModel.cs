using AcessoConta.Api.Common.Enums.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Domain.Transferencia.ReadModel
{
    public class TransferenciaReadModel
    {
        public TransferenciaReadModel()
        {
            TrasnferenciaErroReadModel = new TrasnferenciaErroReadModel();
        }


        public int Id { get; set; }
        public string IdTransferencia { get;  set; }
        public EStatusTransferencia StatusTrasferencia { get;  set; }
        public TrasnferenciaErroReadModel TrasnferenciaErroReadModel { get;  set; }

        public virtual void ValidarStatusTrasnsacao()
        {
            if (TrasnferenciaErroReadModel != null)
            {
                StatusTrasferencia = EStatusTransferencia.Erro;
            }
        
        }
    }
}
