using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Application.Transferencia.Dto
{
    public class TransferenciaDto
    {
        public string ContaOrigem { get; set; }
        public string ContaDestino { get; set; }
        public float Valor { get; set; }
    }
}
