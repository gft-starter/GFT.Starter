using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Repository;
using Infrastructure.Configuration;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ServiceOrderRepository : IRepository<ServiceOrder>
    {
        private readonly LataVelhaContext _db;

        public ServiceOrderRepository(LataVelhaContext db)
        {
            _db = db;
        }

        public IEnumerable<ServiceOrder> Get() => _db
              .ServiceOrders
              .Include(so => so.Car)
              .Include(so => so.Service)
              .ToList();

        public ServiceOrder Find(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Car)
            .Include(so => so.Service)
            .FirstOrDefault(so => so.Id == id);

        public ServiceOrder FidByVehicle(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Car)
            .FirstOrDefault(so => so.CarId == id);

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
