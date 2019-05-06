using System;
using System.Collections.Generic;
using System.Text;
using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;

namespace GFT.Starter.Application.Factories
{
    public class CarFactory : IFactory<Car>
    {
        public Car Create()
        {
            var car = new Car();
            car.Model = "Palio";
            car.Year = 2008;
            car.Brand = "Fiat";
            car.Color = "Preto";
            car.Plate = "DZY-0412";

            return car;
        }

        public Car Create(string model, int year, string brand, string color, string plate, Guid ownerId)
        {
            var car = new Car();
            car.Model = model;
            car.Year = year;
            car.Brand = brand;
            car.Color = color;
            car.Plate = plate;
            car.OwnerId = ownerId;

            return car;

        }

        public Car Update (Car car, string model, int year, string brand, string color, string plate, Guid ownerId)
        {
            car.Model = model;
            car.Year = year;
            car.Brand = brand;
            car.Color = color;
            car.Plate = plate;
            car.OwnerId = ownerId;

            return car;
        }
    }
}
