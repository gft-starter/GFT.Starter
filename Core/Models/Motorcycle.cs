using System;

namespace GFT.Starter.Core.Models
{
    public class Motorcycle : Vehicle
    {
        public void ChangeTire1()
        {
        }

        public void ChangeTire2()
        {
        }

        public override void ChangeTires()
        {
            ChangeTire1();
            ChangeTire2();
        }
    }
}
