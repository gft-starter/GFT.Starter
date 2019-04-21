using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using GFT.Starter.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository;
        private readonly UpgradePartsService _vehicleService;
        private readonly EmailService _emailService;

        public CarController()
        {
            _carRepository = new CarRepository();
            _vehicleService = new UpgradePartsService();
            _emailService = new EmailService();
        }

        [HttpGet]
        public IActionResult Vehicles()
        {
            return Ok(_carRepository.Get());
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
            _carRepository.Add(car);
            _emailService.SendEmail($"Car {car.Id} created successfully!", $"Car {car.Id} created successfully!");
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Car car)
        {
            var obj = FindCar(id);

            obj.Year = car.Year;
            obj.Color = car.Color;

            _emailService.SendEmail($"Car {obj.Id} created successfully!", $"Car {obj.Id} created successfully!");
            return Ok(_carRepository.Update(obj));
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
                return Ok(_carRepository.Remove(obj));

            return NotFound(obj);
        }

        private Car FindCar(Guid id)
        {
            return _carRepository.Find(id);
        }
    }
}
