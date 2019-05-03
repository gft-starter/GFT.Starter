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
        //public abstract int PriceMultiplier { get; }
        //public abstract void ChangeTires();
    }
}
