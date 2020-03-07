using CompanySolution.Domain.Entites;
using CompanySolution.Infra.Data.Context;
using CompanySolution.Infra.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Infra.Data.Repository
{
    public class PhoneRepository : BaseRepository<Phone>
    {
        public PhoneRepository(CompanySolutionContext dbContext) : base(dbContext)
        {
        }
    }
}
