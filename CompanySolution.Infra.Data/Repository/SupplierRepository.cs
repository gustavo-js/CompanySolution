using CompanySolution.Domain.Entites;
using CompanySolution.Domain.Interfaces;
using CompanySolution.Infra.Data.Context;
using CompanySolution.Infra.Data.Repository.Base;
using CompanySolution.Service.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanySolution.Infra.Data.Repository
{
    public class SupplierRepository : BaseRepository<Supplier>
    {
        private readonly IService<Company> companyService;
        public SupplierRepository(CompanySolutionContext dbContext, IService<Company> _companyService, IService<Phone> _phoneService) : base(dbContext)
        {
            companyService = _companyService;
        }
        public override IEnumerable<Supplier> GetAll()
        {
            return _dbContext.Set<Supplier>().Include(s => s.Company).ToList();
        }
        public override Supplier GetById(long id)
        {
            return _dbContext.Set<Supplier>().Include(s => s.Company).ToList().Find(supplier => supplier.Id == id);
        }
        public override Supplier Create(Supplier entity)
        {
            if (entity.CompanyId > 0)
                entity.Company = companyService.Get(entity.CompanyId);

            return base.Create(entity);
        }
    }
}
