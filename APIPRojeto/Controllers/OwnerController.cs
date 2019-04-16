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
        static OwnerRepository owners = new OwnerRepository();

        // GET: api/Owner
        [HttpGet]
        public IActionResult Owners()
        {
            return Ok(owners);
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
                return Ok(owners.Remove(obj));

            return NotFound(obj);
        }

        public Owner FindOwner(Guid Id)
        {
            return owners.Find(Id);
        }
    }
}
