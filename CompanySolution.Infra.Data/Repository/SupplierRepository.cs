using CompanySolution.Domain.Entites;
using CompanySolution.Infra.Data.Context;
using CompanySolution.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanySolution.Infra.Data.Repository
{
    public class SupplierRepository : BaseRepository<Supplier>
    {
        public SupplierRepository(CompanySolutionContext dbContext) : base(dbContext)
        {
        }
        public override IEnumerable<Supplier> GetAll()
        {
            return _dbContext.Set<Supplier>().Include(s => s.Phone).Include(s => s.Company).ToList();
        }
    }
}
