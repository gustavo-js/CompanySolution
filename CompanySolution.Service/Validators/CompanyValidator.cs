using CompanySolution.Domain.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Service.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.TradingName)
                    .NotEmpty().WithMessage("Informe o nome fantasia.")
                    .NotNull().WithMessage("Informe o nome fantasia.");
        }
    }
}
