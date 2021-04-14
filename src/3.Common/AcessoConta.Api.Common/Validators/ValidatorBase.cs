using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Common.Validators
{
    public class ValidatorBase
    {
        public virtual bool Valid { get; protected set; } = true;

        public virtual ValidationResult ValidationResult { get; protected set; }

        protected virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            if (this.Valid)
            {
                this.ValidationResult = validator.Validate(model);
                this.Valid = ValidationResult.IsValid;
            }

            return this.Valid;
        }

        public virtual void IsNotValid(string message = null)
        {
            this.Valid = false;

            if (!string.IsNullOrEmpty(message))
            {
                this.ValidationResult = new ValidationResult(new[]
                {
                    new ValidationFailure(string.Empty,message)
                });
            }
        }
    }
}
