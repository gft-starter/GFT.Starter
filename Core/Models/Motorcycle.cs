using System;

namespace GFT.Starter.Core.Models
{
    public class Motorcycle : Vehicle
    {
        public override void ChangeTire1()
        {
        }

        public override void ChangeTire2()
        {
        }

        public override void ChangeTire3()
        {
            throw new InvalidOperationException();
        }

        public override void ChangeTire4()
        {
            throw new InvalidOperationException();
        }
    }
}
