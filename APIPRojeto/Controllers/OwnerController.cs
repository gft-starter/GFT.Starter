using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPRojeto.Models;

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

        // GET: api/Owner
        [HttpGet]
        public IActionResult Owners()
        {
            return Ok(ownerRepository.Get());
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public IActionResult Owner(Guid Id)
        {
            var obj = FindOwner(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostOwner([FromBody] Owner owner)
        {
            owners.Add(owner);

            return Ok(owner);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid Id, [FromBody] Owner owner)
        {
            var obj = FindOwner(Id);

            obj.Name = owner.Name;

            return Ok(obj);
        }

        // DELETE: api/ApiWithActions/5
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
