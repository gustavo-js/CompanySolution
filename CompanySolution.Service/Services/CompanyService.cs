using CompanySolution.Domain.Entites;
using CompanySolution.Domain.Interfaces;
using CompanySolution.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Service.Services
{
    public class CompanyService : BaseService<Company>
    {
        public CompanyService(IRepository<Company> repository) : base(repository)
        {
        }
    }
}
