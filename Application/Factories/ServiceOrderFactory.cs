using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class ServiceOrderFactory : IFactory<ServiceOrder>
    {
        public ServiceOrder Create()
        {
            var serviceOrder = new ServiceOrder();
            serviceOrder.Quantity = 15;
            return serviceOrder;
        }

        public ServiceOrder Create(int quantity, Guid carId, Guid serviceId, Car car, Service service)
        {
            var serviceOrder = new ServiceOrder();
            serviceOrder.Id = Guid.NewGuid();
            serviceOrder.Quantity = quantity;
            serviceOrder.CarId = carId;
            serviceOrder.ServiceId = serviceId;
            serviceOrder.Service = service;
            serviceOrder.Car = car;
            return serviceOrder;
        }
    }
}
