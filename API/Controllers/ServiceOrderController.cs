using System;
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
        //private readonly IReadOnlyRepository<ServiceOrder> _serviceOrdeReadOnlyRepository;
        //private readonly IWriteRepository<ServiceOrder> _serviceOrderWriteRepository;


        private readonly FacadeRepository _facadeRepository;

        public ServiceOrderController(FacadeRepository facadeRepository)
        {
            _facadeRepository = facadeRepository;
        }
       

        [HttpGet]
        public IActionResult ServiceOrders()
        {
            return Ok(_facadeRepository.ReadAllServiceOrder());
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
            _facadeRepository.AddServiceOrder(serviceOrder);

            return Ok(serviceOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceOrder(Guid id, [FromBody] ServiceOrder serviceOrder)
        {
            var obj = FindServiceOrder(id);

            obj.Quantity = serviceOrder.Quantity;
            _facadeRepository.UpdateServiceOrder(obj);

            return Ok(obj);
        }

        

        private ServiceOrder FindServiceOrder(Guid id)
        {
            return _facadeRepository.ReadServiceOrder(id);
        }
    }
}
