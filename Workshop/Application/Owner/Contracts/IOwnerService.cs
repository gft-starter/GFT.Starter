using System;
using System.Collections.Generic;
using Application.Owner.DTOs;

namespace Application.Owner.Contracts
{
    public interface IOwnerService
    {
        void Add(OwnerDto dto);
        IEnumerable<OwnerDto> Get();
        OwnerDto GetById(Guid id);
        IEnumerable<CarDto> GetCars();
        void Remove(OwnerDto dto);
        void Update(OwnerDto dto);
    }
}