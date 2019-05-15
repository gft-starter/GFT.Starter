using Application.Factories.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class ServiceOrderFactory : IFactory<ServiceOrder>
    {
        public ServiceOrder Create()
        {
            return new ServiceOrder();
        }

        public ServiceOrder Create(Guid ServiceId, Guid VehicleId, int qnt)
        {
            return new ServiceOrder
            {
                Id = Guid.NewGuid(),
                Quantity = qnt,
                ServiceId = ServiceId,
                VehicleId = VehicleId
            };
        }
    }
}
