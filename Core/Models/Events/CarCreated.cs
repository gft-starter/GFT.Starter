﻿namespace Core.Models.Events
{
    public class CarCreated
    {
    
        public  CarCreated(Car car)
        {
            Car = car;
        }

    public Car Car { get; set; }
    }
}