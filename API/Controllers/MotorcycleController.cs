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
    public class MotorcycleController : ControllerBase
    {
        private readonly MotorcycleRepository motorcycleRepository;
        private readonly UpgradePartsService _vehicleService;

        public MotorcycleController()
        {
            motorcycleRepository = new MotorcycleRepository();
            _vehicleService = new UpgradePartsService();
        }

        [HttpGet]
        public IActionResult Vehicles()
        {
            return Ok(motorcycleRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Vehicle(Guid id)
        {
            var obj = FindMotorcycle(id);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult PostVehicle([FromBody] Motorcycle motorcycle)
        {
            motorcycleRepository.Add(motorcycle);
            SendEmail(motorcycle.Id);
            return Ok(motorcycle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Motorcycle motorcycle)
        {
            var obj = FindMotorcycle(id);

            obj.Year = motorcycle.Year;
            obj.Color = motorcycle.Color;

            return Ok(motorcycleRepository.Update(obj));
        }

        [HttpPut("changetires/{id}")]
        public IActionResult ChangeTires(Guid id)
        {
            var obj = FindMotorcycle(id);
            _vehicleService.ChangeTires(obj);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(Guid id)
        {
            var obj = FindMotorcycle(id);

            if (obj != null)
                return Ok(motorcycleRepository.Remove(obj));

            return NotFound(obj);
        }

        private Motorcycle FindMotorcycle(Guid id)
        {
            return motorcycleRepository.Find(id);
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
