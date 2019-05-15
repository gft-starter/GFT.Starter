using Application.Factories.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class OwnerFactory : IFactory<Owner>
    {
        public Owner Create()
        {
            var owner = new Owner
            {
                CPF = "",
                Name = "",
                Gender = 'A',
                BirthDate = DateTime.Now
            };

            return owner;
        }

        public Owner Create(string name, string cpf, char gender, DateTime birthdate)
        {
            var owner = new Owner
            {
                Id = Guid.NewGuid(),
                CPF = cpf,
                Name = name,
                Gender = gender,
                BirthDate = birthdate
            };

            return owner;
        }
    }
}
