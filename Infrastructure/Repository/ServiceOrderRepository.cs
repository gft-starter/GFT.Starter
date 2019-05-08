using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Repository.Contracts;
using Infrastructure.Configuration;

namespace Infrastructure.Repository
{
    public class ServiceOrderRepository : IReadOnlyRepository<ServiceOrder>, IWriteRepository<ServiceOrder>
    {
        private readonly LataVelhaContext _db;

        public ServiceOrderRepository(LataVelhaContext db)
        {
            _db = db;
        }

        public IEnumerable<ServiceOrder> Get() => _db
         .ServiceOrders
         .Include(so => so.Car)
         .Include(so => so.Car.Owner)
         .Include(so => so.Service)
         .ToList();

        public ServiceOrder Find(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Car)
            .Include(so => so.Car.Owner)
            .Include(so => so.Service)
            .FirstOrDefault(so => so.Id == id);

        public ServiceOrder FindCar(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Car)
            .FirstOrDefault(so => so.CarId == id);

        public ServiceOrder FindService(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Service)
            .Include(so => so.Car)
            .FirstOrDefault(so => so.ServiceId == id);

        public void Add(ServiceOrder serviceOrder)
        {
            if (serviceOrder != null)
            {
                _db.Add(serviceOrder);
                _db.SaveChanges();
            }
        }

        public ServiceOrder Remove(ServiceOrder serviceOrder)
        {
            if (serviceOrder != null)
            {
                _db.Remove(serviceOrder);
                _db.SaveChanges();
            }
            return serviceOrder;
        }
        public ServiceOrder Update(ServiceOrder serviceOrder)
        {
            if (serviceOrder != null)
            {
                _db.Update(serviceOrder);
                _db.SaveChanges();
            }
            return serviceOrder;
        }
    }

}
