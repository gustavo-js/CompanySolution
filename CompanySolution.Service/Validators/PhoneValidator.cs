using CompanySolution.Domain.Entites;
using CompanySolution.Service.Validators.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Service.Validators
{
    public class PhoneValidator : BaseValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("Informe o número de telefone.")
                .NotNull().WithMessage("Informe o número de telefone.");
        }
    }
}
