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
                return serviceOrder.Quantity * serviceOrder.Service.Value * 1;
            }
            else if (serviceOrder.Vehicle is Truck)
            {
                return serviceOrder.Quantity * serviceOrder.Service.Value * 2;
            }

            throw new InvalidOperationException("Invalid vehicle type");
        }
    }
}
