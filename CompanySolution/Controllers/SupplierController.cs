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
    public class SupplierController : Controller
    {
        private readonly IService<Supplier> supplierService;
        public SupplierController(IService<Supplier> _supplierService)
        {
            this.supplierService = _supplierService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetAll()
        {
            return supplierService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Supplier> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return supplierService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Supplier supplierModel)
        {
            if (ModelState.IsValid)
            {
                Supplier insertedSupplier = supplierService.Post<SupplierValidator>(supplierModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Supplier supplierModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Supplier supplier = supplierService.Get(id);
                supplier.Company = supplierModel.Company;
                supplier.CompanyId = supplierModel.CompanyId;
                supplier.CNPJ = supplierModel.CNPJ;
                supplier.CPF = supplierModel.CPF;
                supplier.BirthDate = supplierModel.BirthDate;
                supplier.Name = supplierModel.Name;

                var LastUpdatedSupplier = supplierService.Put<SupplierValidator>(supplier);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            supplierService.Delete(id);
        }
    }
}