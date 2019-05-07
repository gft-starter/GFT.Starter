using System;

namespace GFT.Starter.Core.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public Car(Car carToCopy)
        {
            Id = carToCopy.Id;
            Plate = carToCopy.Plate;
            Brand = carToCopy.Brand;
            Model = carToCopy.Model;
            Color = carToCopy.Color;
            Color = carToCopy.Color;
        }
        public Car()
        {

        }
    }
}
