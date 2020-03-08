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
            RuleFor(supplier => supplier.Name)
                .NotEmpty().WithMessage("Informe o nome do fornecedor.")
                .NotNull().WithMessage("Informe o nome do fornecedor.");

            RuleFor(supplier => supplier.RG)
                .NotEmpty().WithMessage("É necessário informar o RG para fornecedores cadastrados como pessoa física.")
                .NotNull().WithMessage("É necessário informar o RG para fornecedores cadastrados como pessoa física.")
                .When(supplier => supplier.IsNaturalPerson);

            RuleFor(supplier => supplier.BirthDate)
                .NotEmpty().WithMessage("É necessário informar a data de nascimento para fornecedores cadastrados como pessoa física.")
                .NotNull().WithMessage("É necessário informar a data de nascimento para fornecedores cadastrados como pessoa física.")
                .When(supplier => supplier.IsNaturalPerson);

            RuleFor(supplier => supplier.IsNaturalPerson)
                .NotEqual(true)
                .When(supplier => supplier.BirthDate.Date > DateTime.Now.Date.AddYears(-18) && supplier.Company.FederatedUnit.Equals(FederatedUnits.PR))
                .WithMessage("Fornecedores cadastrados como pessoa física no Paraná não podem ser menores de idade.");
        }
    }
}
