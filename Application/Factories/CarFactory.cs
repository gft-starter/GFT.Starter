using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class CarFactory
    {
        public Car Create()
        {
            var car = new Car();
            car.Model = "Palio";
            car.Year = 2008;
            car.Brand = "FIAT";
            car.Color = "Preto";
            car.Plate = "ABC1234";


            return car;
        }

        public Car Create(string model, int year, string brand, string color, string plate, Guid ownerId)
        {
            var car = new Car();
            car.Model = model;
            car.Brand = brand;
            car.Color = color;
            car.Plate = plate;
            car.OwnerId = ownerId;

            return car;
        }

        public Car Update(Car car, string model, int year, string brand, string color, string plate, Guid ownerId)
        {
            car.Model = model;
            car.Brand = brand;
            car.Color = color;
            car.Plate = plate;
            car.OwnerId = ownerId;

            return car;
        }
    }
}
