using System;

namespace GFT.Starter.Core.Models
{
    public class Car : ICar
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public bool Deleted { get; set; }

        public void Update(Person person)
        {
            Deleted = person.Deleted;
        }
    }
}
