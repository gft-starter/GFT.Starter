using System;
using System.Net;
using System.Net.Mail;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
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
            SendEmail(car.Id);
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Car car)
        {
            var obj = FindCar(id);

            obj.Year = car.Year;
            obj.Color = car.Color;

            return Ok(_carRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(Guid id)
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

        public void SendEmail(Guid id)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("gftstarter@gmail.com", "Gft@2019@1");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("gftstarter@gmail.com");
            mailMessage.To.Add("gftstarter@gmail.com");
            mailMessage.Body = $"Vehicle {id} created successfully!";
            mailMessage.Subject = $"Vehicle {id} created successfully!";
            client.Send(mailMessage);
        }
    }
}
