using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class ServiceOrderFactory
    {
        public ServiceOrder Create()
        {
            var serviceOrder = new ServiceOrder();
            serviceOrder.Quantity = 10;

            return serviceOrder;
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
