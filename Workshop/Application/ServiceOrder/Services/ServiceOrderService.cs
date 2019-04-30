using System;
using System.Collections.Generic;
using System.Linq;
using Application.Service.DTOs;
using Application.ServiceOrder.Contracts;
using Application.ServiceOrder.DTOs;
using AutoMapper;
using DomainModel.Services;
using Helpers.Repository;

namespace Application.ServiceOrder.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IRepository<Infrastructure.Models.ServiceOrder> _serviceOrderRepository;
        private readonly IRepository<Infrastructure.Models.Service> _serviceRepository;
        private readonly TaxService _taxService;

        public ServiceOrderService(IRepository<Infrastructure.Models.ServiceOrder> serviceOrderRepository,
            IRepository<Infrastructure.Models.Service> serviceRepository, TaxService taxService)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _serviceRepository = serviceRepository;
            _taxService = taxService;
        }

        public IEnumerable<ServiceOrderDto> Get()
        {
            IEnumerable<Infrastructure.Models.ServiceOrder> serviceOrders = _serviceOrderRepository.Get();
            foreach (Infrastructure.Models.ServiceOrder serviceOrder in serviceOrders)
            {
                yield return GetById(serviceOrder.Id);
            }
        }

        public IEnumerable<ServiceDto> GetServices()
        {
            IEnumerable<Infrastructure.Models.Service> services = _serviceRepository.Get();
            foreach (Infrastructure.Models.Service service in services)
            {
                yield return Mapper.Map<ServiceDto>(service.Id);
            }
        }

        public ServiceOrderDto GetById(Guid id)
        {
            Infrastructure.Models.ServiceOrder serviceOrder = _serviceOrderRepository.Find(id);
            DomainModel.Owner.Owner owner = DomainModel.Owner.Owner.CreateOwner(serviceOrder.Car.Owner.Id, serviceOrder.Car.Owner.Name, serviceOrder.Car.Owner.Cpf, serviceOrder.Car.Owner.BirthDate, serviceOrder.Car.Owner.Gender);
            DomainModel.Owner.Car car = DomainModel.Owner.Car.CreateCar(serviceOrder.Car.Plate, serviceOrder.Car.Brand, serviceOrder.Car.Model,
                serviceOrder.Car.Color, serviceOrder.Car.Year, owner);
            List<DomainModel.Service.Service> services = serviceOrder.Service
                .Select(x => DomainModel.Service.Service.CreateService(x.Name, x.Description, x.Value)).ToList();

            var domain = DomainModel.ServiceOrder.ServiceOrder.CreateServiceOrder(serviceOrder.Id, car, services);
            foreach (DomainModel.Service.Service service in services)
            {
                domain.AddService(service);
            }

            return Mapper.Map<ServiceOrderDto>(domain);
        }

        public void Add(ServiceOrderDto dto)
        {
            DomainModel.Owner.Owner owner = DomainModel.Owner.Owner.CreateOwner(dto.Car.Owner.Id, dto.Car.Owner.Name, dto.Car.Owner.Cpf, dto.Car.Owner.BirthDate, dto.Car.Owner.Gender);
            DomainModel.Owner.Car car = DomainModel.Owner.Car.CreateCar(dto.Car.Plate, dto.Car.Brand, dto.Car.Model,
                dto.Car.Color, dto.Car.Year, owner);
            List<DomainModel.Service.Service> services = dto.Services
                .Select(x => DomainModel.Service.Service.CreateService(x.Id, x.Name, x.Description, x.Value)).ToList();

            var domain = DomainModel.ServiceOrder.ServiceOrder.CreateServiceOrder(car, services);
            foreach (DomainModel.Service.Service service in services)
            {
                domain.AddService(service);
            }
            _serviceOrderRepository.Add(Mapper.Map<Infrastructure.Models.ServiceOrder>(domain));
        }

        public void Remove(ServiceOrderDto dto)
        {
            _serviceOrderRepository.Remove(Mapper.Map<Infrastructure.Models.ServiceOrder>(dto));
        }

        public void Update(ServiceOrderDto dto)
        {
            DomainModel.Owner.Owner owner = DomainModel.Owner.Owner.CreateOwner(dto.Car.Owner.Id, dto.Car.Owner.Name, dto.Car.Owner.Cpf, dto.Car.Owner.BirthDate, dto.Car.Owner.Gender);
            DomainModel.Owner.Car car = DomainModel.Owner.Car.CreateCar(dto.Car.Plate, dto.Car.Brand, dto.Car.Model,
                dto.Car.Color, dto.Car.Year, owner);
            List<DomainModel.Service.Service> services = dto.Services
                .Select(x => DomainModel.Service.Service.CreateService(x.Name, x.Description, x.Value)).ToList();

            var domain = DomainModel.ServiceOrder.ServiceOrder.CreateServiceOrder(dto.Id, car, services);
            foreach (DomainModel.Service.Service service in services)
            {
                domain.UpdateService(service);
            }

            _serviceOrderRepository.Update(Mapper.Map<Infrastructure.Models.ServiceOrder>(domain));
        }

        public float CalculateTotalPrice(DomainModel.ServiceOrder.ServiceOrder serviceOrder)
        {
            return serviceOrder.CalculateValue() + _taxService.CalculateTaxes(serviceOrder);
        }
    }
}
