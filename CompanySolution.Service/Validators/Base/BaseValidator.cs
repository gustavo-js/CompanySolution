using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Service.Validators.Base
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                    });
        }
    }
}
