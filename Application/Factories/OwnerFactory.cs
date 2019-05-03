using System;
using System.Collections.Generic;
using System.Text;
using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;

namespace GFT.Starter.Application.Factories
{
    public class OwnerFactory : IFactory<Owner>
    {
        public Owner Create()
        {
            var owner = new Owner();
            owner.CPF = "123.456.789-12";
            owner.Name = "Joazinho";
            owner.Gender = 'M';
            owner.BirthDate = DateTime.Now;

            return owner;
        }

        //public Owner Create(string cpf, string name, char gender, DateTime birthDate)
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
