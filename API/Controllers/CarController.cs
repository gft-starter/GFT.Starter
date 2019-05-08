using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Core.Models.Commands;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using GFT.Starter.Infrastructure.ServiceBus.Contracts;
using GFT.Starter.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IReadOnlyRepository<Car> _carReadOnlyRepository;
        private readonly IWriteRepository<Car> _carWriteRepository;
        private readonly IUpgradePartsService _vehicleService;
        private readonly IEmailService _emailService;
        private readonly IServiceBusClient _busClient;

        public CarController(IReadOnlyRepository<Car> carReadOnlyRepository, IWriteRepository<Car> carWriteRepository, IUpgradePartsService vehicleService, IEmailService emailService, IServiceBusClient busClient)
        {
            _carReadOnlyRepository = carReadOnlyRepository;
            _carWriteRepository = carWriteRepository;
            _vehicleService = vehicleService;
            _emailService = emailService;
            _busClient = busClient;
        }

        [HttpGet]
        public IActionResult Vehicles()
        {
            return Ok(_carReadOnlyRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Vehicle(Guid id)
        {
            var obj = FindCar(id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostVehicle([FromBody] Car car)
        {
            _busClient.SendMessageToQueue(new CreateCar(car));
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Car car)
        {
            var obj = FindCar(id);

            obj.Year = car.Year;
            obj.Color = car.Color;

            _emailService.SendEmail($"Car {obj.Id} created successfully!", $"Car {obj.Id} created successfully!");
            return Ok(_carWriteRepository.Update(obj));
        }

        [HttpPut("changetires/{id}")]
        public IActionResult ChangeTires(Guid id)
        {
            Vehicle obj = FindCar(id);
            _vehicleService.ChangeTires(obj);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(Guid id)
        {
            var obj = FindCar(id);

            if (obj != null)
                return Ok(_carWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Car FindCar(Guid id)
        {
            return _carReadOnlyRepository.Find(id);
        }
    }
}
