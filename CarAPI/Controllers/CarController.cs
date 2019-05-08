﻿using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IReadOnlyRepository<Car> _carReadOnlyRepository;
        private readonly IWriteRepository<Car> _carWriteRepository;

        public CarController(IReadOnlyRepository<Car> carReadOnlyRepository, IWriteRepository<Car> carWriteRepository)
        {
            _carReadOnlyRepository = carReadOnlyRepository;
            _carWriteRepository = carWriteRepository;
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
            _carWriteRepository.Add(car);
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Car car)
        {
            var obj = FindCar(id);

            obj.Year = car.Year;
            obj.Color = car.Color;
            return Ok(_carWriteRepository.Update(obj));
        }

        [HttpPut("changetires/{id}")]
        public IActionResult ChangeTires(Guid id)
        {
            Car obj = FindCar(id);
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