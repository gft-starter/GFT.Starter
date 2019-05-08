using System;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Repository;
using Infrastructure.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IReadOnlyRepository<ServiceOrder> _serviceOrdeReadOnlyRepository;
        private readonly IWriteRepository<ServiceOrder> _serviceOrderWriteRepository;
        
        public ServiceOrderController(IReadOnlyRepository<ServiceOrder> serviceOrdeReadOnlyRepository, IWriteRepository<ServiceOrder> serviceOrderWriteRepository)
        {
            _serviceOrdeReadOnlyRepository = serviceOrdeReadOnlyRepository;
            _serviceOrderWriteRepository = serviceOrderWriteRepository;
            
        }


        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(_serviceOrdeReadOnlyRepository.Get());
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
            _serviceOrderWriteRepository.Add(serviceOrder);

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
            return _serviceOrdeReadOnlyRepository.Find(Id);
        }
    }
}
