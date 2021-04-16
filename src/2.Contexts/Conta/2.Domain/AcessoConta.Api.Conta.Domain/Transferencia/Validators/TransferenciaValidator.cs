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
            ValidateConta();

        }

        private void ValidateValor()
        {
            RuleFor(i => i.Valor)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("O Valor não pode ser zero.");
        }

        private void ValidateConta()
        {
            RuleFor(i => i.Conta)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("A Conta  é obrigatorio");
        }
       
    }
}
