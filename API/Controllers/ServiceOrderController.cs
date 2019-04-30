using System;
using Application.ServiceOrder.Contracts;
using Application.ServiceOrder.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;

        public ServiceOrderController(IServiceOrderService serviceOrderService)
        {
            _serviceOrderService = serviceOrderService;
        }

        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(_serviceOrderService.Get());
        }


        [HttpGet("{id}")]
        public IActionResult ServiceOrder(Guid id)
        {
            return Ok(_serviceOrderService.GetById(id));
        }

        [HttpPost]
        public IActionResult PostServiceOrder([FromBody] ServiceOrderDto service)
        {
            _serviceOrderService.Add(service);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceOrder(Guid id, [FromBody] ServiceOrderDto service)
        {
            _serviceOrderService.Add(service);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteServiceOrder(Guid id)
        {
            _serviceOrderService.Remove(new ServiceOrderDto { Id = id });
            return Ok();
        }
    }
}
