using Core.Models;
using Infrastructure.Configuration;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ServiceOrderRepository : IReadOnlyRepository<ServiceOrder>, IWriteRepository<ServiceOrder>
    {
        private readonly LataNovaContext _db;

        public ServiceOrderRepository(LataNovaContext db)
        {
            _db = db;
        }

        public IEnumerable<ServiceOrder> Get() => _db
              .ServiceOrders
              .Include(so => so.Vehicle)
              .Include(so => so.Service)
              .ToList();

        public ServiceOrder Find(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Vehicle)
            .Include(so => so.Service)
            .FirstOrDefault(so => so.Id == id);

        public ServiceOrder FidByVehicle(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Vehicle)
            .FirstOrDefault(so => so.VehicleId == id);

        public ServiceOrder FindByService(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Service)
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
