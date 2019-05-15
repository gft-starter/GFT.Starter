using API.Commands;
using API.Commands.Contracts;
using API.Managers;
using Core.Models;
using Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
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
        public IActionResult Service(Guid id)
        {
            var obj = _serviceReadOnlyRepository.Find(id);
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
            obj.Description = service.Description;
            obj.Value = service.Value;

            return Ok(_serviceWriteRepository.Update(obj));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteServiceOrder(Guid id)
        {
            if (CommandManager
                .Invoke(new DeleteCommand<Service>(
                    id,
                    _serviceWriteRepository,
                    _serviceReadOnlyRepository)))
                return Ok();
            return NotFound();
        }

        private Service FindService(Guid id)
        {
            return _serviceReadOnlyRepository.Find(id);
        }
    }
}
