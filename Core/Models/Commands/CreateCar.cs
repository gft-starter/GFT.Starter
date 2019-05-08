using System;

namespace GFT.Starter.Core.Models.Commands
{
    public class CreateCar
    {
        public CreateCar(Car car)
        {
            Car = car;
        }

        public Car Car { get; set; }
    }
}
