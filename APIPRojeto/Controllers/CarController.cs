using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPRojeto.Models;
using APIPRojeto.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace APIPRojeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        static List<Car> cars = new List<Car>();
        private readonly CarRepository carRepository;

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
            if (car == null)
            {
                return new NotFoundResult();
            }
            carRepository.Add(car);
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid Id, [FromBody] Car car)
        {
            var obj = carRepository.Find(Id);

            obj.Year = car.Year;

            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid Id)
        {
            var obj = carRepository.Find(Id);

            if (obj != null)
                return Ok(cars.Remove(obj));

            return NotFound(obj);
        }

        
    }
}
