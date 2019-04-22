using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using APIPRojeto.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRepository carRepository;

        public CarController()
        {
            carRepository = new CarRepository();
        }

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(carRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Car(Guid Id)
        {
            var obj = carRepository.Find(Id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] Car car)
        {
            carRepository.Add(car);

            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid Id, [FromBody] Car car)
        {
            var obj = carRepository.Find(Id);

            obj.Year = car.Year;
            obj.Color = car.Color;
            
            return Ok(carRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid Id)
        {
            var obj = carRepository.Find(Id);

            if (obj != null)
                return Ok(carRepository.Remove(obj));

            return NotFound(obj);
        }
    }
}
