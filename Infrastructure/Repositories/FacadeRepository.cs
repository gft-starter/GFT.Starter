using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Configuration;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class FacadeRepository
    {
        private IWriteRepository<Owner> OwnerWrite { get; }
        private IReadOnlyRepository<Owner> OwnerRead { get; }
        private IWriteRepository<ServiceOrder> ServiceOrderWrite { get; }
        private IReadOnlyRepository<ServiceOrder> ServiceOrderRead { get; }
        private IWriteRepository<Car> CarWrite { get; }
        private IReadOnlyRepository<Car> CarRead { get; }

        public FacadeRepository(IWriteRepository<Owner> ownerWrite, IReadOnlyRepository<Owner> ownerRead, IWriteRepository<ServiceOrder> serviceOrderWrite, IReadOnlyRepository<ServiceOrder> serviceOrderRead, IWriteRepository<Car> carWrite, IReadOnlyRepository<Car> carRead)
        {
            OwnerWrite = ownerWrite;
            OwnerRead = ownerRead;
            ServiceOrderWrite = serviceOrderWrite;
            ServiceOrderRead = serviceOrderRead;
            CarWrite = carWrite;
            CarRead = carRead;
        }


        public IEnumerable<Owner> ReadAllOwner()
        {
            return OwnerRead.Get();
        }
        public Owner ReadOwner(Guid id)
        {
            return OwnerRead.Find(id);
        }
        public Owner RemoveOwner(Owner owner)
        {
            return OwnerWrite.Remove(owner);
        }
        public void AddOwner(Owner owner)
        {
            OwnerWrite.Add(owner);
        }
        public Owner UpdateOwner(Owner owner)
        {
            return OwnerWrite.Update(owner);
        }


        public IEnumerable<Car> ReadAllCar()
        {
            return CarRead.Get();
        }
        public Car ReadCar(Guid id)
        {
            return CarRead.Find(id);
        }
        public Car RemoveCar(Car car)
        {
            return CarWrite.Remove(car);
        }
        public void AddCar(Car car)
        {
            CarWrite.Add(car);
        }
        public Car UpdateCar(Car car)
        {
            return CarWrite.Update(car);
        }


        public IEnumerable<ServiceOrder> ReadAllServiceOrder()
        {
            return ServiceOrderRead.Get();
        }
        public ServiceOrder ReadServiceOrder(Guid id)
        {
            return ServiceOrderRead.Find(id);
        }
        public ServiceOrder RemoveServiceOrder(ServiceOrder serviceOrder)
        {
            return ServiceOrderWrite.Remove(serviceOrder);
        }
        public void AddServiceOrder(ServiceOrder serviceOrder)
        {
            ServiceOrderWrite.Add(serviceOrder);
        }
        public ServiceOrder UpdateServiceOrder(ServiceOrder serviceOrder)
        {
            return ServiceOrderWrite.Update(serviceOrder);
        }
    }
}
