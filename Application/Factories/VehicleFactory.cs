using Application.Factories.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class VehicleFactory : IFactory<Vehicle>
    {
        public Vehicle Create()
        {
            var vehicle = new Vehicle();
            vehicle.Brand = "Marca";
            vehicle.Color = "Cor";
            vehicle.Model = "Modelo";
            vehicle.Plate = "PLACA";
            vehicle.Year = 1234;


            return vehicle;
        }

        public Vehicle Create(string brand, string color, string model, string plate, int year, Guid ownerId)
        {
            var vehicle = new Vehicle();
            vehicle.Id = Guid.NewGuid();
            vehicle.Model = model;
            vehicle.Brand = brand;
            vehicle.Color = color;
            vehicle.Plate = plate;
            vehicle.Year = year;
            vehicle.OwnerId = ownerId;

            return vehicle;
        }

        public Vehicle Update(Vehicle vehicle, string brand, string color, string model, string plate, int year, Guid ownerId)
        {
            var updatedVehicle = new Vehicle();
            updatedVehicle.Id = vehicle.Id;
            updatedVehicle.Brand = brand;
            updatedVehicle.Color = color;
            updatedVehicle.Model = model;
            updatedVehicle.Plate = plate;
            updatedVehicle.Year = year;
            updatedVehicle.OwnerId = ownerId;
            return updatedVehicle;
        }
    }
}
