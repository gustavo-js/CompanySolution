using CompanySolution.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Domain.Entites
{
    public class Supplier : EntityBase
    {
        public Company Company { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string RG { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsNaturalPerson { get; set; }
    }
}
