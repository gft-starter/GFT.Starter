using API.Commands;
using API.Managers;
using Core.Models;
using Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IReadOnlyRepository<ServiceOrder> _serviceOrderReadOnlyRepository;
        private readonly IWriteRepository<ServiceOrder> _serviceOrderWriteRepository;

        public ServiceOrderController(IReadOnlyRepository<ServiceOrder> serviceOrdeReadOnlyRepository, IWriteRepository<ServiceOrder> serviceOrderWriteRepository)
        {
            _serviceOrderReadOnlyRepository = serviceOrdeReadOnlyRepository;
            _serviceOrderWriteRepository = serviceOrderWriteRepository;
        }

        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(_serviceOrderReadOnlyRepository.Get());
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
            obj.ServiceId = serviceOrder.ServiceId;
            obj.VehicleId = serviceOrder.VehicleId;

            return Ok(_serviceOrderWriteRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServiceOrder(Guid id)
        {
            if (CommandManager
                .Invoke(new DeleteCommand<ServiceOrder>(
                    id,
                    _serviceOrderWriteRepository,
                    _serviceOrderReadOnlyRepository)))
                return Ok();
            return NotFound();
        }

        private ServiceOrder FindServiceOrder(Guid id)
        {
            return _serviceOrderReadOnlyRepository.Find(id);
        }
    }
}
