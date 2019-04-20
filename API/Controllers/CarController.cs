using System;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository;

        public CarController()
        {
            _carRepository = new CarRepository();
        }

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(_carRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Car(Guid id)
        {
            var obj = FindCar(id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] Car car)
        {
            _carRepository.Add(car);

            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid id, [FromBody] Car car)
        {
            var obj = FindCar(id);

            obj.Year = car.Year;
            obj.Color = car.Color;

            return Ok(_carRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid id)
        {
            var obj = FindCar(id);

            if (obj != null)
                return Ok(_carRepository.Remove(obj));

            return NotFound(obj);
        }

        public Car FindCar(Guid id)
        {
            return _carRepository.Find(id);
        }
    }
}
