using System;

namespace GFT.Starter.Core.Models
{
    public class Car
    {
        public Car() { }
        public Car(Car cartoCopy)
        {
            Id = cartoCopy.Id;
            Plate = cartoCopy.Plate;
            Brand = cartoCopy.Brand;
            Model = cartoCopy.Model;
            Color = cartoCopy.Color;
            Year = cartoCopy.Year;
            OwnerId = cartoCopy.OwnerId;
        }
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
