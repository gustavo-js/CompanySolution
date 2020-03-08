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
        private readonly IRepository<Company> _companyRepository;
        public SupplierService(IRepository<Supplier> repository, IRepository<Company> companyRepository) : base(repository)
        {
            _companyRepository = companyRepository;
        }
        public override Supplier Post<V>(Supplier entity)
        {
            entity.Company = _companyRepository.GetById(entity.CompanyId);
            return base.Post<V>(entity);
        }
        public override Supplier Put<V>(Supplier entity)
        {
            entity.Company = _companyRepository.GetById(entity.CompanyId);
            return base.Post<V>(entity);
        }
    }
}
