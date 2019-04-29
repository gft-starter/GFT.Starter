﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using APIPRojeto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        static List<ServiceOrder> serviceOrders = new List<ServiceOrder>();
        private readonly ServiceOrderRepository serviceOrderRepository;

        public ServiceOrderController()
        {
            serviceOrderRepository = new ServiceOrderRepository();
        }

        
        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(serviceOrderRepository.Get());
        }

        
        [HttpGet("{id}")]
        public IActionResult ServiceOrder(Guid Id)
        {
            var obj = FindServiceOrder(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostServiceOrder([FromBody] ServiceOrder serviceOrder)
        {
            serviceOrderRepository.Add(serviceOrder);

            return Ok(serviceOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceOrder(Guid Id, [FromBody] ServiceOrder serviceOrder)
        {
            var obj = FindServiceOrder(Id);

            obj.Quantity = serviceOrder.Quantity;

            return Ok(obj);
        }

        private ServiceOrder FindServiceOrder(Guid Id)
        {
            return serviceOrderRepository.Find(Id);
        }
    }
}
