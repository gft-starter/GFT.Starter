using Application.Adapters;
using Core.Models;
using Infrastructure.Commands;
using Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IReadOnlyRepository<Vehicle> _VehicleReadOnlyRepository;
        private readonly IWriteRepository<Vehicle> _VehicleWriteRepository;
        private readonly IReadOnlyRepository<VehicleHistoryAdapter> _HistoryReadOnlyRepository;

        public VehicleController(IReadOnlyRepository<Vehicle> VehicleReadOnlyRepository, IWriteRepository<Vehicle> VehicleWriteRepository, IReadOnlyRepository<VehicleHistoryAdapter> HistoryReadOnlyRepository)
        {
            _VehicleReadOnlyRepository = VehicleReadOnlyRepository;
            _VehicleWriteRepository = VehicleWriteRepository;
            _HistoryReadOnlyRepository = HistoryReadOnlyRepository;
        }

        [HttpGet]
        public IActionResult Vehicles()
        {
            return Ok(_VehicleReadOnlyRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Vehicle(Guid id)
        {
            var obj = FindVehicle(id);
            return Ok(obj);
        }

        [HttpGet("history")]
        public IActionResult VehicleHistory([FromBody] GetVehicleHistoryCommand command)
        {
            command.GetHistory(_HistoryReadOnlyRepository);
            return Ok(command.vehicleHistory);
        }

        [HttpPost]
        public IActionResult PostVehicle([FromBody] Vehicle Vehicle)
        {
            _VehicleWriteRepository.Add(Vehicle);
            return Ok(Vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] Vehicle Vehicle)
        {
            var obj = FindVehicle(id);

            obj.Year = Vehicle.Year;
            obj.Color = Vehicle.Color;
            obj.Brand = Vehicle.Brand;
            obj.Model = Vehicle.Model;
            obj.Plate = Vehicle.Plate;

            return Ok(_VehicleWriteRepository.Update(obj));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(Guid id)
        {
            var obj = FindVehicle(id);

            if (obj != null)
                return Ok(_VehicleWriteRepository.Remove(obj));

            return NotFound(obj);
        }

        private Vehicle FindVehicle(Guid id)
        {
            return _VehicleReadOnlyRepository.Find(id);
        }
    }
}
