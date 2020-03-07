using CompanySolution.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Domain.Entites
{
    public class Company : EntityBase
    {
        public string FederatedUnit { get; set; }
        public string TradingName { get; set; }
        public string CNPJ { get; set; }
    }
}
