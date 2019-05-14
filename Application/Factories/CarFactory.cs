using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class CarFactory : IFactory<Car>
    {
        public Car Create()
        {
            var car = new Car();
            car.Model = "Palio";
            car.Year = 2008;
            car.Brand = "FIAT";
            car.Color = "Preto";
            car.Plate = "ABC-1234";

            return car;
        }

        public Car Create(string plate, string brand, string model, string color, int year, Guid ownerId, Owner owner)
        {
            var car = new Car();
            car.Id = Guid.NewGuid();
            car.Plate = plate;
            car.Brand = brand;
            car.Model = model;
            car.Color = color;
            car.Year = year;
            car.OwnerId = ownerId;
            car.Owner = owner;
            return car;
        }

        public Car Update(Car car, string plate, string brand, string model, string color, int year, Guid ownerId)
        {
            Car newCar = new Car(car);
            newCar.Plate = plate;
            newCar.Brand = brand;
            newCar.Model = model;
            newCar.Color = color;
            newCar.Year = year;
            newCar.OwnerId = ownerId;
            
            return newCar;
        }
    }
}
