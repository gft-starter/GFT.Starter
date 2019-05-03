using System;
using System.Collections.Generic;
using System.Text;
using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;

namespace GFT.Starter.Application.Factories
{
    public class ServiceOrderFactory : IFactory<ServiceOrder>
    {
        public ServiceOrder Create()
        {
            var serviceOrder = new ServiceOrder();
            serviceOrder.Quantity = 10;
            
            return serviceOrder;
        }
    }
}
