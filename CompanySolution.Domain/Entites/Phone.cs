using CompanySolution.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Domain.Entites
{
    public class Phone : EntityBase
    {
        public string Number { get; set; }
        public Supplier Supplier { get; set; }
        public long SupplierId { get; set; }
    }
}
