using System;
using Application.Interfaces;
using Core.Models;

namespace Application.Factories
{
    public class CarsFactory : IFactory<Car>
    {
        public Car Create()
        {
            var car = new Car();
            car.Model = "Palio";
            car.Year = 2000;
            car.Brand = "Fiat";
            car.Color = "Prata";
            car.Plate = "XBA-1122";



            return new Car();
        }

        public Car Create(string brand, string plate, string color, int year, string model, Guid idowner)
        {
            var car = new Car();
            car.Id = Guid.NewGuid();
            car.Brand = brand;
            car.Plate = plate;
            car.Model = model;
            car.Color = color;
            car.Year = year;
            car.OwnerId = idowner;

            return new Car();
        }

    }
}
