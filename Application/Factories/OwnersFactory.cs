using System;
using Application.Interfaces;
using Core.Models;

namespace Application.Factories
{
    public class OwnersFactory : IFactory<Owner>
    {
        public Owner Create()
        {
            var owner = new Owner();
            owner.CPF = "123.456.789-12";
            owner.Name = "Joaozinho";
            owner.Gender = 'M';
            owner.BirthDate = DateTime.Now;


            return new Owner();
        }

        public Owner Create(string name, string cpf, char gender, DateTime birthDate)
        {
            var owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.CPF = cpf;
            owner.Name = name;
            owner.Gender = gender;
            owner.BirthDate = birthDate;

            
            return new Owner();
        }


        
    }
}
