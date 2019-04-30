using System;

namespace GFT.Starter.Core.Models
{
    public class Motorcycle : Vehicle
    {
        public override void ChangeFourTires()
        {
            throw new InvalidOperationException();
        }
    }
}
