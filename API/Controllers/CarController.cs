using System;
using System.Net;
using System.Net.Mail;
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
        private readonly IReadOnlyRepository<Car> _carReadOnlyRepository;
        private readonly IWriteRepository<Car> _carWriteRepository;
        private readonly UpgradePartsService _vehicleService;

        public CarController()
        {
            _carReadOnlyRepository = new CarRepository();
            _carWriteRepository = new CarRepository();
            _vehicleService = new UpgradePartsService();
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
            SendEmail(car.Id);
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
            var obj = FindCar(id);
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

        private void SendEmail(Guid id)
        {
            var fromAddress = new MailAddress("gftstarter@gmail.com", "GFT Starter");
            var toAddress = new MailAddress("gftstarter@gmail.com", "GFT Starter");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "Gft@2019@1")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = $"Vehicle {id} created successfully!",
                Body = $"Vehicle {id} created successfully!"
            })
            {
                smtp.Send(message);
            }
        }
    }
}
