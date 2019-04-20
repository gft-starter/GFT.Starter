using System;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceController()
        {
            _serviceRepository = new ServiceRepository();
        }


        [HttpGet]
        public IActionResult Services()
        {
            return Ok(_serviceRepository.Get());
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
            _serviceRepository.Add(service);

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
                return Ok(_serviceRepository.Remove(obj));

            return NotFound(obj);
        }

        public Service FindService(Guid id)
        {
            return _serviceRepository.Find(id);
        }
    }
}
