using System;
using System.Collections.Generic;
using Application.Service.DTOs;
using Application.ServiceOrder.DTOs;

namespace Application.ServiceOrder.Contracts
{
    public interface IServiceOrderService
    {
        void Add(ServiceOrderDto dto);
        IEnumerable<ServiceOrderDto> Get();
        IEnumerable<ServiceDto> GetServices();
        ServiceOrderDto GetById(Guid id);
        void Remove(ServiceOrderDto dto);
        void Update(ServiceOrderDto dto);
    }
}