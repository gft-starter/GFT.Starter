using System;
using Application.ServiceOrder.Contracts;
using Application.ServiceOrder.DTOs;
using Application.ServiceOrder.Services;
using DomainModel.ServiceOrder;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Services()
        {
            return Ok(_serviceService.Get());
        }


        [HttpGet("{id}")]
        public IActionResult Service(Guid id)
        {
            return Ok(_serviceService.GetById(id));
        }

        [HttpPost]
        public IActionResult PostService([FromBody] ServiceDto service)
        {
            _serviceService.Add(service);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(Guid id, [FromBody] ServiceDto service)
        {
            _serviceService.Add(service);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(Guid id)
        {
            _serviceService.Remove(new ServiceDto { Id = id });
            return Ok();
        }
    }
}
