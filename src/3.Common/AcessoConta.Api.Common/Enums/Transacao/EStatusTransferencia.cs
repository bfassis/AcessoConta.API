using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcessoConta.Api.Common.Enums.Transacao
{
    public enum EStatusTransferencia
    {
        [Display(Name = "Confirmado")]
        Confirmado = 1,
        [Display(Name = "Erro")]
        Erro = 2
    }
}
