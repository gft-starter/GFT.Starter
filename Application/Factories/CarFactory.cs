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

        //public Car Create(string cpf, string name, char gender, DateTime birthDate)
        //{
        //    var owner = new Owner();
        //    owner.Id = Guid.NewGuid();
        //    owner.CPF =cpf;
        //    owner.Name = name;
        //    owner.Gender = gender;
        //    owner.BirthDate = birthDate;

        //    return owner;

        //}
    }
}
