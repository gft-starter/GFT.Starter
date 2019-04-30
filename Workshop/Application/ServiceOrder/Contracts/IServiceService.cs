using System;
using System.Collections.Generic;
using Application.ServiceOrder.DTOs;

namespace Application.ServiceOrder.Contracts
{
    public interface IServiceService
    {
        void Add(ServiceDto dto);
        ServiceDto GetById(Guid id);
        IEnumerable<ServiceDto> Get();
        void Remove(ServiceDto dto);
        void Update(ServiceDto dto);
    }
}