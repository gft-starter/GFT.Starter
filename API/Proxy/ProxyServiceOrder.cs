using GFT.Starter.Core.Models;
using GFT.Starter.Core.Models.Interfaces;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.Starter.API.Proxy
{
    public class ProxyServiceOrder : IServiceOrder
    {

        //private readonly IReadOnlyRepository<ServiceOrder> _serviceOrdeReadOnlyRepository;
        public ServiceOrder ChangeStatus(ServiceOrderStatus status, Guid id)
        {
            //ServiceOrder ServiceOrder = _serviceOrdeReadOnlyRepository.Find(id);
            ServiceOrder ServiceOrder = new ServiceOrder();
            if (ServiceOrder != null)
            {
                //ServiceOrder.ChangeStatus(status);
            }
            return ServiceOrder;
        }
    }
}
