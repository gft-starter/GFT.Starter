using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Models.Commands
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
