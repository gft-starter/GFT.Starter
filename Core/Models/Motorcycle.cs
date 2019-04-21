using System;

namespace GFT.Starter.Core.Models
{
    public class Motorcycle : Vehicle
    {
        public override int PriceMultiplier { get; } = 1;

        public override void ChangeFourTires()
        {
            throw new InvalidOperationException();
        }
    }
}
