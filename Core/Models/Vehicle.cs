using System;

namespace GFT.Starter.Core.Models
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public abstract void ChangeTire1();
        public abstract void ChangeTire2();
        public abstract void ChangeTire3();
        public abstract void ChangeTire4();
    }
}
