using System;
using System.Collections.Generic;
using System.Linq;
using Application.Owner.Contracts;
using Application.Owner.DTOs;
using AutoMapper;
using Helpers.Repository;

namespace Application.Owner.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository<Infrastructure.Models.Owner> _ownerRepository;
        private readonly IRepository<Infrastructure.Models.Car> _carRepository;
        public OwnerService(IRepository<Infrastructure.Models.Owner> ownerRepository, IRepository<Infrastructure.Models.Car> carRepository)
        {
            _ownerRepository = ownerRepository;
            _carRepository = carRepository;
        }

        public IEnumerable<OwnerDto> Get()
        {
            IEnumerable<Infrastructure.Models.Owner> owners = _ownerRepository.Get();
            foreach (Infrastructure.Models.Owner owner in owners)
            {
                yield return GetById(owner.Id);
            }
        }

        public IEnumerable<CarDto> GetCars()
        {
            IEnumerable<Infrastructure.Models.Car> cars = _carRepository.Get();
            foreach (Infrastructure.Models.Car car in cars)
            {
                yield return Mapper.Map<CarDto>(car);
            }
        }

        public OwnerDto GetById(Guid id)
        {
            Infrastructure.Models.Owner owner = _ownerRepository.Find(id);
            List<Infrastructure.Models.Car> cars = _carRepository.Get().Where(x => x.OwnerId == owner.Id).ToList();

            var domain = DomainModel.Owner.Owner.CreateOwner(owner.Name, owner.Cpf, owner.BirthDate, owner.Gender);
            if (cars.Any())
            {
                foreach (Infrastructure.Models.Car car in cars)
                {
                    domain.AddCar(DomainModel.Owner.Car.CreateCar(car.Plate, car.Brand, car.Model, car.Color, car.Year, domain));
                }
            }

            return Mapper.Map<OwnerDto>(domain);
        }

        public void Add(OwnerDto dto)
        {
            var owner = DomainModel.Owner.Owner.CreateOwner(dto.Name, dto.Cpf, dto.BirthDate, dto.Gender);
            foreach (CarDto carDto in dto.Cars)
            {
                owner.AddCar(DomainModel.Owner.Car.CreateCar(carDto.Plate, carDto.Brand, carDto.Model, carDto.Color, carDto.Year, owner));
            }
            _ownerRepository.Add(Mapper.Map<Infrastructure.Models.Owner>(owner));
        }

        public void Remove(OwnerDto dto)
        {
            _ownerRepository.Remove(Mapper.Map<Infrastructure.Models.Owner>(dto));
        }

        public void Update(OwnerDto dto)
        {
            var owner = DomainModel.Owner.Owner.CreateOwner(dto.Name, dto.Cpf, dto.BirthDate, dto.Gender);
            _ownerRepository.Update(Mapper.Map<Infrastructure.Models.Owner>(owner));
        }
    }
}