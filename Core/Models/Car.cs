using System;

namespace Core.Models
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
        public int PriceMultiplier { get; } = 2;

    }
}
