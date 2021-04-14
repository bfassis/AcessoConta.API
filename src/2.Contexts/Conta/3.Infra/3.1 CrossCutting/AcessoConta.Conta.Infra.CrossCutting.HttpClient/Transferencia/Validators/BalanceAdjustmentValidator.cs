using AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Response;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Conta.Infra.CrossCutting.HttpClient.Transferencia.Validators
{
    public class BalanceAdjustmentValidator : AbstractValidator<BalanceAdjustmentResponse>
    {

        public BalanceAdjustmentValidator()
        {
            ValidateAccountNumber();
            ValidateValue();


        }

        private void ValidateAccountNumber()
        {
            RuleFor(i => i.AccountNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("A Conta informada não existe");
        }

        private void ValidateValue()
        {
            RuleFor(i => i.Balance)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("Conta sem saldo para transferencia");
        }

    }
}
