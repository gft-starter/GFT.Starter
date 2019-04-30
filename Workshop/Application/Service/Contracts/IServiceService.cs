using System;
using System.Collections.Generic;
using Application.Service.DTOs;

namespace Application.Service.Contracts
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