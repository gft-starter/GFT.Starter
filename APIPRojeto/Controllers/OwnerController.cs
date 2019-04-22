using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPRojeto.Models;
using APIPRojeto.Repositories;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        static List<Owner> owners = new List<Owner>();
        private readonly OwnerRepository ownerRepository;

        public OwnerController()
        {
            ownerRepository = new OwnerRepository();
        }
        [HttpGet]
        public IActionResult Owner()
        {
            return Ok(ownerRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Owner(Guid Id)
        {
            var obj = FindOwner(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostOwner([FromBody] Owner owner)
        {
            ownerRepository.Insert(owner);

            return Ok(owner);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid Id, [FromBody] Owner owner)
        {
            var obj = FindOwner(Id);

            obj.CPF = owner.CPF;
            obj.Gender = owner.Gender;

            return Ok(ownerRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid Id)
        {
            var obj = FindOwner(Id);

            if (obj != null)
                return Ok(ownerRepository.Remove(obj));

            return NotFound(obj);
        }

        public Owner FindOwner(Guid Id)
        {
            return ownerRepository.Find(Id);
        }
    }
}
