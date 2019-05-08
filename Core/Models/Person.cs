using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Core.Models
{
    public abstract class Person
    {
        public bool Deleted
        {
            get { return Deleted; }
            set
            {
                if (Deleted != value)
                {
                    Deleted = value;
                    Notify();
                }
            }
        }

        public List<ICar> Cars = new List<ICar>();
        
        public void Attach(ICar restaurant)
        {
            Cars.Add(restaurant);
        }

        public void Detach(ICar restaurant)
        {
            Cars.Remove(restaurant);
        }

        public void Notify()
        {
            foreach (ICar Car in Cars)
            {
                Car.Update(this);
            }

            Console.WriteLine("");
        }
        
    }
}
