﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        static List<Car> cars = new List<Car>();

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(cars);
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
            cars.Add(car);

            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid Id, [FromBody] Car car)
        {
            var obj = FindCar(Id);

            obj.Year = car.Year;

            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid Id)
        {
            var obj = FindCar(Id);

            if (obj != null)
                return Ok(cars.Remove(obj));

            return NotFound(obj);
        }

        public Car FindCar(Guid Id)
        {
            return cars.Find(x => x.Id == Id);
        }
    }
}
