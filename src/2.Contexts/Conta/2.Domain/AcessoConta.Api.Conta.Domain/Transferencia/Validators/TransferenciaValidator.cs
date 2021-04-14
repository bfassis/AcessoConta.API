using AcessoConta.Api.Conta.Domain.Transferencia.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Conta.Domain.Transferencia.Validators
{
    public class TransferenciaValidator : AbstractValidator<TransferenciaEntity>
    {
        public TransferenciaValidator()
        {
            ValidateValor();
            ValidateContaOrigem();
            ValidateContaDestino();

        }

        private void ValidateValor()
        {
            RuleFor(i => i.Valor)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("O Valor não pode ser zero.");
        }

        private void ValidateContaOrigem()
        {
            RuleFor(i => i.ContaOrigem)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O Conta Origem é obrigatorio");
        }
        private void ValidateContaDestino()
        {
            RuleFor(i => i.ContaDestino)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O Conta Destino é obrigatorio");
        }
    }
}
