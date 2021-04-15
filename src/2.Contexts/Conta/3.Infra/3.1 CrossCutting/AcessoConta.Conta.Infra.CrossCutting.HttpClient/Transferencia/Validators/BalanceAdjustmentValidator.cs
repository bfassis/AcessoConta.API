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
        }

        private void ValidateAccountNumber()
        {
            RuleFor(i => i.AccountNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("A Conta informada não existe");
        }

    }
}
