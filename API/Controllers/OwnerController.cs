using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerRepository _ownerRepository;

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }

        // GET: api/Owner
        [HttpGet]
        public IActionResult Owners()
        {
            return Ok(_ownerRepository.Get());
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public IActionResult Owner(Guid id)
        {
            var obj = FindOwner(id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostOwner([FromBody] Owner owner)
        {
            _ownerRepository.Add(owner);

            return Ok(owner);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid id, [FromBody] Owner owner)
        {
            var obj = FindOwner(id);

            obj.Name = owner.Name;

            return Ok(obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            var obj = FindOwner(id);

            if (obj != null)
                return Ok(_ownerRepository.Remove(obj));

            return NotFound(obj);
        }

        private Owner FindOwner(Guid id)
        {
            return _ownerRepository.Find(id);
        }
    }
}
