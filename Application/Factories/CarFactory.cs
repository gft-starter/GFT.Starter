using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class CarFactory
    {
        public Car Create(string Model, int Year, string Brand, string Color, string Plate, Guid ownerid)
        {
            var car = new Car( );
            car.Model = Model;
            car.Year = Year;
            car.Brand = Brand;
            car.Color = Color;
            car.Plate = Plate;
            car.OwnerId = ownerid;


            return car;
        }

        public Car Update(Car car, string model, int year, string brand, string color, string plate, Guid ownerId)

        {
            var newCar = new Car(car);
            newCar.Model = model;
            newCar.Year = year;
            newCar.Brand = brand;
            newCar.Color = color;
            newCar.Plate = plate;
            newCar.OwnerId = ownerId;
            return newCar;
        }

        
    }
}
