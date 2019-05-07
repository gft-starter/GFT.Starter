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

        private readonly FacadeRepository _facadeRepository;

        public ServiceController(FacadeRepository facadeRepository)
        {
            _facadeRepository = facadeRepository;
        }

        [HttpGet]
        public IActionResult Services()
        {
            return Ok(_facadeRepository.ReadAllCar());
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
            //_facadeRepository.AddServiceOrder(service);

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
                //return Ok(_facadeRepository.RemoveServiceOrder(obj));
                return Ok(obj);


            return NotFound(obj);
        }

        private Service FindService(Guid id)
        {
            //return _facadeRepository.ReadServiceOrder(id);
            return new Service();
        }
    }
}
