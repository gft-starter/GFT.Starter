using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        //private readonly IReadOnlyRepository<Car> _carReadOnlyRepository;
        //private readonly IWriteRepository<Car> _carWriteRepository;

        //public CarController(IReadOnlyRepository<Car> carReadOnlyRepository, IWriteRepository<Car> carWriteRepository)
        //{
        //    _carReadOnlyRepository = carReadOnlyRepository;
        //    _carWriteRepository = carWriteRepository;

        //}

        private readonly FacadeRepository _facadeRepository;

        public CarController(FacadeRepository facadeRepository)
        {
            _facadeRepository = facadeRepository;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            return Ok(_facadeRepository.ReadAllCar());
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
            _facadeRepository.AddCar(car);
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid id, [FromBody] Car car)
        {
            var obj = FindCar(id);

            obj.Year = car.Year;
            obj.Color = car.Color;

            return Ok(_facadeRepository.UpdateCar(obj));
        }

        [HttpPut("changetires/{id}")]
        public IActionResult ChangeTires(Guid id)
        {
            Car obj = FindCar(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid id)
        {
            var obj = FindCar(id);

            if (obj != null)
                return Ok(_facadeRepository.RemoveCar(obj));

            return NotFound(obj);
        }

        private Car FindCar(Guid id)
        {
            return _facadeRepository.ReadCar(id);
        }
    }
}
