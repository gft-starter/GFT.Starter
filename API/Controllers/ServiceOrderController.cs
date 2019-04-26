﻿using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using GFT.Starter.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IReadOnlyRepository<ServiceOrder> _serviceOrdeReadOnlyRepository;
        private readonly IWriteRepository<ServiceOrder> _serviceOrderWriteRepository;
        private readonly ServiceOrderCalculator _serviceOrderCalculator;

        public ServiceOrderController()
        {
            _serviceOrdeReadOnlyRepository = new ServiceOrderRepository();
            _serviceOrderWriteRepository = new ServiceOrderRepository();
            _serviceOrderCalculator = new ServiceOrderCalculator();
        }


        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(_serviceOrdeReadOnlyRepository.Get());
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
            _serviceOrderWriteRepository.Add(serviceOrder);

            return Ok(serviceOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceOrder(Guid id, [FromBody] ServiceOrder serviceOrder)
        {
            var obj = FindServiceOrder(id);

            obj.Quantity = serviceOrder.Quantity;
            _serviceOrderWriteRepository.Update(obj);

            return Ok(obj);
        }

        [HttpGet("Calculate")]
        public IActionResult CalculatePrice(Guid id)
        {
            var obj = FindServiceOrder(id);
            return Ok(_serviceOrderCalculator.CalculateTotalPrice(obj));
        }

        private ServiceOrder FindServiceOrder(Guid id)
        {
            return _serviceOrdeReadOnlyRepository.Find(id);
        }
    }
}
