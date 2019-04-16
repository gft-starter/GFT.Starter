using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using APIPRojeto.Repositorires;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        static List<Service> services = new List<Service>();
        private readonly ServiceRepository serviceRepository;
        public ServiceController()
        {
            serviceRepository = new ServiceRepository();
        }
        [HttpGet]
        public IActionResult Services()
        {
            return Ok(serviceRepository.Get());
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
            serviceRepository.Insert(service);

            return Ok(service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(Guid Id, [FromBody] Service service)
        {
            var obj = FindService(Id);

            obj.Description = service.Description;
            obj.Name = service.Name;

            return Ok(serviceRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(Guid Id)
        {
            var obj = FindService(Id);

            if (obj != null)
                return Ok(serviceRepository.Remove(obj));

            return NotFound(obj);
        }

        public Service FindService(Guid Id)
        {
            return serviceRepository.Find(Id);
        }
    }
}
