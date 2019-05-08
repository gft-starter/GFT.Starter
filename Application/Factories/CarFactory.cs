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
            car.Model = model;
            car.Year = year;
            car.Brand = brand;
            car.Color = color;
            car.Plate = plate;
            car.OwnerId = ownerId;
            return car;
        }

        //public Car Create(string cpf, string name, char gender, DateTime birthDate)
        //{
        //    var owner = new Owner();
        //    owner.Id = Guid.NewGuid();
        //    owner.CPF = cpf;
        //    owner.Name = name;
        //    owner.Gender = gender;
        //    owner.BirthDate = birthDate;

        //    return owner;
        //}
    }
}
