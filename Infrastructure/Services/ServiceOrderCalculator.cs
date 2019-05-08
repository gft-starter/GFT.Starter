using Core.Models;
using Infrastructure.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class ServiceOrderCalculator : IServiceOrderCalcualtor
    {

        public double CalculatorTotalPrice(ServiceOrder serviceOrder)
        {
            double value = 2.00;
            //return serviceOrder.Quantity * serviceOrder.Service.Value * serviceOrder.Car.PriceMultiplier;
            return value;
        }
    }
}
