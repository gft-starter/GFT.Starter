using System;
using GFT.Starter.API.Observer;
using GFT.Starter.API.Proxy;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
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
            _serviceOrderWriteRepository.Update(obj);

            return Ok(obj);
        }

        //[HttpPut("status/{id}")]
        //public IActionResult UpdateStatus(Guid id, [FromBody] ServiceOrderStatus status)
        //{
        //    ProxyServiceOrder proxyServiceOrder = new ProxyServiceOrder();

        //    Car car = new Car();

        //    //car.SetStatus(CarStatus.Free);

        //    //StatusObserver statusObserver = new StatusObserver(car);
        //    //ServiceOrder serviceOrder = new ServiceOrder(statusObserver);

        //    //serviceOrder = proxyServiceOrder.ChangeStatus(status, id);
        //    //_serviceOrderWriteRepository.Update(serviceOrder);

        //    return Ok(serviceOrder);
        //}

        private ServiceOrder FindServiceOrder(Guid id)
        {
            return _serviceOrdeReadOnlyRepository.Find(id);
        }
    }
}
