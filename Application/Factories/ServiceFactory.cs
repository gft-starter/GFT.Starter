using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class ServiceFactory
    {
        public Service Create()
        {
            var service = new Service();
            service.Name = "Service";
            service.Description = "Descricao";
            service.Value = 100;


            return service;
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
