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
    public class ServiceController : ControllerBase
    {
        static ServiceRepository services = new ServiceRepository();

        // GET: api/Owner
        [HttpGet]
        public IActionResult Services()
        {
            return Ok(services);
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public IActionResult Service(Guid Id)
        {
            var obj = services.Find(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostService([FromBody] Service service)
        {
            services.Add(service);

            return Ok(service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(Guid Id, [FromBody] Service service)
        {
            var obj = services.Find(Id);

            obj.Name = service.Name;

            return Ok(obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(Guid Id)
        {
            var obj = services.Find(Id);

            if (obj != null)
                return Ok(services.Remove(obj));

            return NotFound(obj);
        }
    }
}
