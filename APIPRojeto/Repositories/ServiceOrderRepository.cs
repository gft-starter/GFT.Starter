using APIPRojeto.Models;
using APIPRojeto.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositories
{
    public class ServiceOrderRepository : BaseRepository
    {
        public IEnumerable<ServiceOrder> Get() => Db
            .ServiceOrder
            .Include(c => c.Car)
            .Include(s => s.Service)
            .ToList();

        public ServiceOrder Find(Guid id) => Db
            .ServiceOrder
            .Include(c => c.Car)
            .Include(s => s.Service)
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add(ServiceOrder serviceOrder)
        {
            if (serviceOrder != null)
            {
                Db.Add(serviceOrder);
                Db.SaveChanges();
            }
        }

        public ServiceOrder Remove(ServiceOrder serviceOrder)
        {
            if (serviceOrder != null)
            {
                Db.Remove(serviceOrder);
                Db.SaveChanges();
            }

            return serviceOrder;
        }

        public ServiceOrder Update(ServiceOrder serviceOrder)
        {
            if (serviceOrder != null)
            {
                Db.Update(serviceOrder);
                Db.SaveChanges();
            }

            return serviceOrder;
        }
    }
}
