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
