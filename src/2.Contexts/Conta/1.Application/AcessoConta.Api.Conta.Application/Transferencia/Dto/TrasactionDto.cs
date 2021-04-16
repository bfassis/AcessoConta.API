using AcessoConta.Api.Common.Enums.Transacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Dto
{
    public class TrasactionDto
    {
        public string transactionId { get; set; }

        [EnumDataType(typeof(EStatusTransferencia))]
        public string Status { get; set; }       
        public string Message { get; set; }
    }
}
