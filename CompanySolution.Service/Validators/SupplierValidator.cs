using CompanySolution.Domain.Entites;
using CompanySolution.Service.Validators.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Service.Validators
{
    public class SupplierValidator : BaseValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Informe o nome do fornecedor.")
                .NotNull().WithMessage("Informe o nome do fornecedor.");
        }
    }
}
