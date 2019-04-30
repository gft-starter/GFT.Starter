using System;
using Application.Owner.Contracts;
using Application.Owner.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owner
        [HttpGet]
        public IActionResult Owners()
        {
            return Ok(_ownerService.Get());
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public IActionResult Owner(Guid id)
        {
            return Ok(_ownerService.GetById(id));
        }

        [HttpPost]
        public IActionResult PostOwner([FromBody] OwnerDto owner)
        {
            _ownerService.Add(owner);

            return Ok(owner);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid id, [FromBody] OwnerDto owner)
        {
            _ownerService.Update(owner);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            _ownerService.Remove(new OwnerDto { Id = id });
            return Ok();
        }
    }
}
