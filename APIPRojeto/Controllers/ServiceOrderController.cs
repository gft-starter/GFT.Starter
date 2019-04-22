using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using APIPRojeto.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        static ServiceOrderRepository serviceOrders = new ServiceOrderRepository();

        // GET: api/Owner
        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(serviceOrders);
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public IActionResult ServiceOrder(Guid Id)
        {
            var obj = serviceOrders.Find(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostServiceOrder([FromBody] ServiceOrder serviceOrder)
        {
            serviceOrders.Add(serviceOrder);

            return Ok(serviceOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceOrder(Guid Id, [FromBody] ServiceOrder serviceOrder)
        {
            var obj = serviceOrders.Find(Id);

            obj.Quantity = serviceOrder.Quantity;

            return Ok(obj);
        }
    }
}
