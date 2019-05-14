using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class OwnerFactory : IFactory<Owner>
    {
        public Owner Create()
        {
            var owner = new Owner();
            owner.CPF = "123.456.789-12";
            owner.Name = "Joao";
            owner.Gender = 'M';
            owner.BirthDate = DateTime.Now;
            return owner;
        }

        public Owner Create(string name, string cpf, char gender, DateTime birthDate)
        {
            var owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.CPF = cpf;
            owner.Name = name;
            owner.Gender = gender;
            owner.BirthDate = birthDate;
            return owner;
        }
    }
}
