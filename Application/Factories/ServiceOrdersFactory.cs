using Application.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class ServiceOrdersFactory : IFactory<ServiceOrder>
    {
       
        public ServiceOrder Create()
        {
            throw new NotImplementedException();
        }

        public ServiceOrder Create(int quantity, Guid idCar, Guid idService)
        {
            var serviceOrder = new ServiceOrder();
            serviceOrder.Id = Guid.NewGuid();
            serviceOrder.CarId = idCar;
            serviceOrder.ServiceId = idService;


            return new ServiceOrder();
        }
    }
}
