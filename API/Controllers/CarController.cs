using System;
using System.Linq;
using Application.Owner.Contracts;
using Helpers.Service;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public CarController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(_ownerService.GetCars());
        }

        [HttpGet("{id}")]
        public IActionResult Car(Guid id)
        {
            return Ok(_ownerService.GetById(id));
        }
    }
}
