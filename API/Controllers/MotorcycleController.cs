﻿using System;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using GFT.Starter.Infrastructure.Services;
using GFT.Starter.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Starter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IReadOnlyRepository<Motorcycle> _motorcycleReadOnlyRepository;
        private readonly IWriteRepository<Motorcycle> _motorcycleWriteRepository;
        private readonly IUpgradePartsService _vehicleService;
        private readonly IEmailService _emailService;

        public MotorcycleController(IReadOnlyRepository<Motorcycle> motorcycleReadOnlyRepository, IWriteRepository<Motorcycle> motorcycleWriteRepository, IUpgradePartsService vehicleService, IEmailService emailService)
        {
            _motorcycleReadOnlyRepository = motorcycleReadOnlyRepository;
            _motorcycleWriteRepository = motorcycleWriteRepository;
            _vehicleService = vehicleService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Vehicles()
        {
            return Ok(_motorcycleReadOnlyRepository.Get());
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
            _motorcycleWriteRepository.Add(motorcycle);
            _emailService.SendEmail($"Motorcycle {motorcycle.Id} created successfully!", $"Motorcycle {motorcycle.Id} created successfully!");
            return Ok(motorcycle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Motorcycle motorcycle)
        {
            var obj = FindMotorcycle(id);

            obj.Year = motorcycle.Year;
            obj.Color = motorcycle.Color;
            _emailService.SendEmail($"Motorcycle {obj.Id} created successfully!", $"Motorcycle {obj.Id} created successfully!");
            return Ok(_motorcycleWriteRepository.Update(obj));
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
                return Ok(_motorcycleWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Motorcycle FindMotorcycle(Guid id)
        {
            return _motorcycleReadOnlyRepository.Find(id);
        }


    }
}
