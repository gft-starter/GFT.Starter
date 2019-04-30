using System;
using DomainModel.Owner.Events;
using Helpers.Domain;

namespace DomainModel.Owner
{
    public class Car
    {
        public Guid Id { get; private set; }

        public string Plate { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Year { get; private set; }
        public virtual Owner Owner { get; private set; }

        public static Car CreateCar(string plate, string brand, string model, string color, int year, Owner owner)
        {
            if (string.IsNullOrEmpty(plate))
                throw new InvalidOperationException("Please provide a plate number");
            if (year < 1990)
                throw new Exception("Invalid year");
            if (brand.Contains("Tesla"))
                throw new Exception("I don't know how to fix this");

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Plate = plate,
                Brand = brand,
                Model = model,
                Color = color,
                Year = year,
                Owner = owner
            };

            DomainEvents.Raise(new CarCreated { Car = car });

            return car;
        }
    }
}
