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
    public class ServiceController : ControllerBase
    {
        private readonly IReadOnlyRepository<Service> _serviceReadOnlyRepository;
        private readonly IWriteRepository<Service> _serviceWriteRepository;

        public ServiceController(IReadOnlyRepository<Service> serviceReadOnlyRepository, IWriteRepository<Service> serviceWriteRepository)
        {
            _serviceReadOnlyRepository = serviceReadOnlyRepository;
            _serviceWriteRepository = serviceWriteRepository;
        }


        [HttpGet]
        public IActionResult Services()
        {
            return Ok(_serviceReadOnlyRepository.Get());
        }

        
        [HttpGet("{id}")]
        public IActionResult Service(Guid Id)
        {
            var obj = FindService(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostService([FromBody] Service service)
        {
            _serviceWriteRepository.Add(service);

            return Ok(service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(Guid Id, [FromBody] Service service)
        {
            var obj = FindService(Id);

            obj.Name = service.Name;

            return Ok(obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(Guid Id)
        {
            var obj = FindService(Id);

            if (obj != null)
                return Ok(_serviceWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Service FindService(Guid Id)
        {
            return _serviceReadOnlyRepository.Find(Id);
        }
    }
}
