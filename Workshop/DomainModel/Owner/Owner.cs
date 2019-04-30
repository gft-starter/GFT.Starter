using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DomainModel.Owner.Events;
using Helpers.Domain;
using Helpers.Service;

namespace DomainModel.Owner
{
    public class Owner : IAggregateRoot
    {
        public virtual Guid Id { get; private set; }
        private static readonly string[] Genders = { "M", "F" };

        private readonly List<Car> _cars = new List<Car>();

        public virtual ReadOnlyCollection<Car> Vehicles => _cars.AsReadOnly();

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public char Gender { get; private set; }

        public static Owner CreateOwner(string name, string cpf, DateTime birthDate, char gender)
        {
            return CreateOwner(Guid.NewGuid(), name, cpf, birthDate, gender);
        }

        public static Owner CreateOwner(Guid id, string name, string cpf, DateTime birthDate, char gender)
        {
            var owner = new Owner();
            owner.Id = id;
            owner.Name = name;
            owner.BirthDate = birthDate;

            if (DocumentValidator.IsValid(cpf))
                owner.Cpf = cpf;
            else
                throw new InvalidOperationException("Invalid document");
            if (Genders.Contains(gender.ToString().ToUpper()))
                owner.Gender = gender;
            else
                throw new InvalidOperationException("Invalid gender.");

            DomainEvents.Raise(new OwnerCreated { Owner = owner });

            return owner;
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }
    }
}