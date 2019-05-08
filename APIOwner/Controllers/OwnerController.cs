using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Infrastructure.Repository;
using Infrastructure.Repository.Contracts;

namespace APIOwner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IReadOnlyRepository<Owner> _ownerReadOnlyRepository;
        private readonly IWriteRepository<Owner> _ownerWriteRepository;

        public OwnerController(IReadOnlyRepository<Owner> ownerReadOnlyRepository, IWriteRepository<Owner> ownerWriteRepository)
        {
            _ownerReadOnlyRepository = ownerReadOnlyRepository;
            _ownerWriteRepository = ownerWriteRepository;
        }

        // GET: api/Owner
        [HttpGet]
        public IActionResult Owners()
        {
            return Ok(_ownerReadOnlyRepository.Get());
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
            _ownerWriteRepository.Add(owner);

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
                return Ok(_ownerWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Owner FindOwner(Guid Id)
        {
            return _ownerReadOnlyRepository.Find(Id);
        }
    }
}
