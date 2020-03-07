using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySolution.Domain.Entites;
using CompanySolution.Domain.Interfaces;
using CompanySolution.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CompanySolution.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IService<Company> companyService;
        public CompanyController(IService<Company> _companyService)
        {
            this.companyService = _companyService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetAll()
        {
            return companyService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Company> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return companyService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Company companyModel)
        {
            if (ModelState.IsValid)
            {
                Company insertedCompany = companyService.Post<CompanyValidator>(companyModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Company companyModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Company company = companyService.Get(id);
                company.FederatedUnit = companyModel.FederatedUnit;
                company.TradingName = companyModel.TradingName;
                company.CNPJ = companyModel.CNPJ;

                var LastUpdatedCompany = companyService.Put<CompanyValidator>(company);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            companyService.Delete(id);
        }
    }
}