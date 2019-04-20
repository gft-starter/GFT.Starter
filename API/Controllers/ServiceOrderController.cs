using System;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly ServiceOrderRepository _serviceOrderRepository;

        public ServiceOrderController()
        {
            _serviceOrderRepository = new ServiceOrderRepository();
        }

        
        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(_serviceOrderRepository.Get());
        }

        
        [HttpGet("{id}")]
        public IActionResult ServiceOrder(Guid id)
        {
            var obj = FindServiceOrder(id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostServiceOrder([FromBody] ServiceOrder serviceOrder)
        {
            _serviceOrderRepository.Add(serviceOrder);

            return Ok(serviceOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceOrder(Guid id, [FromBody] ServiceOrder serviceOrder)
        {
            var obj = FindServiceOrder(id);

            obj.Quantity = serviceOrder.Quantity;

            return Ok(obj);
        }

        public ServiceOrder FindServiceOrder(Guid id)
        {
            return _serviceOrderRepository.Find(id);
        }
    }
}
