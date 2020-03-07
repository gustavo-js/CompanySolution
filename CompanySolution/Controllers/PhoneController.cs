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
    public class PhoneController : Controller
    {
        private readonly IService<Phone> phoneService;
        public PhoneController(IService<Phone> _phoneService)
        {
            this.phoneService = _phoneService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Phone>> GetAll()
        {
            return phoneService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Phone> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return phoneService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Phone phoneModel)
        {
            if (ModelState.IsValid)
            {
                Phone insertedPhone = phoneService.Post<PhoneValidator>(phoneModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Phone phoneModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Phone phone = phoneService.Get(id);
                phone.Number = phoneModel.Number;

                var LastUpdatedPhone = phoneService.Put<PhoneValidator>(phone);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            phoneService.Delete(id);
        }
    }
}