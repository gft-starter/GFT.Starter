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

        [HttpPut("changetires/{id}")]
        public IActionResult ChangeTires(Guid id)
        {
            var obj = FindCar(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid id)
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
