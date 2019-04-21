using System;
using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public class ServiceOrderCalculator
    {
        public float CalculateTotalPrice(ServiceOrder serviceOrder)
        {
            if (serviceOrder.Vehicle is Car)
            {
                return serviceOrder.Quantity * serviceOrder.Service.Value * 2;
            }

            if (serviceOrder.Vehicle is Motorcycle)
            {
                return serviceOrder.Quantity * serviceOrder.Service.Value * 1;
            }

            throw new InvalidOperationException("Invalid vehicle type");
        }
    }
}
