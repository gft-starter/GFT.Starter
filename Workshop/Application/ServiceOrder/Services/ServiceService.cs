using System;
using System.Collections.Generic;
using Application.ServiceOrder.Contracts;
using Application.ServiceOrder.DTOs;
using AutoMapper;
using DomainModel.ServiceOrder;
using DomainModel.Services;
using Helpers.Repository;

namespace Application.ServiceOrder.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<Infrastructure.Models.Service> _serviceRepository;
        private readonly TaxService _taxService;

        public ServiceService(IRepository<Infrastructure.Models.Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IEnumerable<ServiceDto> Get()
        {
            IEnumerable<Infrastructure.Models.Service> services = _serviceRepository.Get();
            foreach (Infrastructure.Models.Service service in services)
            {
                yield return Mapper.Map<ServiceDto>(service.Id);
            }
        }

        public ServiceDto GetById(Guid id)
        {
            Infrastructure.Models.Service service = _serviceRepository.Find(id);
            return Mapper.Map<ServiceDto>(service);
        }

        public void Add(ServiceDto dto)
        {
            Service service = Service.CreateService(dto.Name, dto.Description, dto.Value);
            _serviceRepository.Add(Mapper.Map<Infrastructure.Models.Service>(service));
        }

        public void Remove(ServiceDto dto)
        {
            _serviceRepository.Remove(Mapper.Map<Infrastructure.Models.Service>(dto));
        }

        public void Update(ServiceDto dto)
        {
            Service service = Service.CreateService(dto.Id, dto.Name, dto.Description, dto.Value);
            _serviceRepository.Add(Mapper.Map<Infrastructure.Models.Service>(service));
        }

    }
}
