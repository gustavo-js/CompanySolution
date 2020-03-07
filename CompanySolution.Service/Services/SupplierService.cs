using CompanySolution.Domain.Entites;
using CompanySolution.Domain.Interfaces;
using CompanySolution.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Service.Services
{
    public class SupplierService : BaseService<Supplier>
    {
        public SupplierService(IRepository<Supplier> repository) : base(repository)
        {
        }
    }
}
