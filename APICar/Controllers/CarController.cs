using System;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Services.Contracts;
using Infrastructure.Repository.Contracts;
using Infrastructure.SeviceBus.Contracts;
using Microsoft.AspNetCore.Mvc;
using Core.Models.Commands;

namespace APICar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IReadOnlyRepository<Car> _carReadOnlyRepository;
        private readonly IWriteRepository<Car> _carWriteRepository;
        private readonly IEmailService _emailService;
        private readonly IServiceBusClient _busClient;


        public CarController(IReadOnlyRepository<Car> carReadOnlyRepository, IWriteRepository<Car> carWriteRepository, IEmailService emailService, IServiceBusClient busClient)
        {
            _carReadOnlyRepository = carReadOnlyRepository;
            _carWriteRepository = carWriteRepository;
            _emailService = emailService;
            _busClient = busClient;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(_carReadOnlyRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Car(Guid Id)
        {
            var obj = FindCar(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] Car car)
        {
            _busClient.SendMessageToQueue(new CreateCar(car));
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid Id, [FromBody] Car car)
        {
            var obj = FindCar(Id);

            obj.Year = car.Year;
            obj.Color = car.Color;

            _emailService.SendEmail($"Car {obj.Id} created successfully!", $"Car {obj.Id} created successfully!");
            return Ok(_carWriteRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid Id)
        {
            var obj = FindCar(Id);

            if (obj != null)
                return Ok(_carWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Car FindCar(Guid Id)
        {
            return _carReadOnlyRepository.Find(Id);
        }
    }
}
