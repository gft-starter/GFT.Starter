using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IReadOnlyRepository<Service> _serviceReadOnlyRepository;
        private readonly IWriteRepository<Service> _serviceWriteRepository;

        public ServiceController()
        {
            _serviceReadOnlyRepository = new ServiceRepository();
            _serviceWriteRepository = new ServiceRepository();
        }


        [HttpGet]
        public IActionResult Services()
        {
            return Ok(_serviceReadOnlyRepository.Get());
        }


        [HttpGet("{id}")]
        public IActionResult Service(Guid id)
        {
            var obj = FindService(id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostService([FromBody] Service service)
        {
            _serviceWriteRepository.Add(service);

            return Ok(service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(Guid id, [FromBody] Service service)
        {
            var obj = FindService(id);

            obj.Name = service.Name;

            return Ok(obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(Guid id)
        {
            var obj = FindService(id);

            if (obj != null)
                return Ok(_serviceWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Service FindService(Guid id)
        {
            return _serviceReadOnlyRepository.Find(id);
        }
    }
}
