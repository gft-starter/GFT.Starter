using Application.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class ServiceOrdersFactory : IFactory<ServiceOrderValue>
    {
       
        public ServiceOrderValue Create()
        {
            throw new NotImplementedException();
        }

        public ServiceOrderValue Create(int quantity, Guid idCar, Guid idService)
        {
            var serviceOrder = new ServiceOrderValue();
            serviceOrder.Id = Guid.NewGuid();
            serviceOrder.CarId = idCar;
            serviceOrder.ServiceId = idService;


            return new ServiceOrderValue();
        }
    }
}
