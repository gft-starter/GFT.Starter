using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        static List<Service> services = new List<Service>();

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
            var obj = FindService(Id);
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
                return Ok(services.Remove(obj));

            return NotFound(obj);
        }

        public Service FindService(Guid Id)
        {
            return services.Find(x => x.Id == Id);
        }
    }
}
