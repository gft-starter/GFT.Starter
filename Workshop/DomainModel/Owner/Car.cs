using System;
using DomainModel.Owner.Events;
using Helpers.Domain;

namespace DomainModel.Owner
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public virtual Owner Owner { get; set; }

        public static Car CreateCar(string plate, string brand, string model, string color, int year, Owner owner)
        {
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
