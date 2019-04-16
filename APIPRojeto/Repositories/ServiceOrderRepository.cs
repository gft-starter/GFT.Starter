using APIPRojeto.Models;
using APIPRojeto.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositories
{
    public class ServiceOrderRepository
    {
        private readonly LataNovaContext _db;

        public ServiceOrderRepository()
        {
            _db = new LataNovaContext();
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
            .Where(c => c.Id == id)
            .FirstOrDefault();

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
