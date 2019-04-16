using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    public class ServiceOrderRepository
    {
        private readonly LataVelhaContext _db;
        public ServiceOrderRepository()
        {
            _db = new LataVelhaContext();

        }
        public IEnumerable<ServiceOrder> Get() => _db.ServiceOrder.Include("Service").Include("Car").ToList();


        public ServiceOrder Find(Guid id) => _db.ServiceOrder.Include("Service").Include("Car").Where(x => x.Id == id).FirstOrDefault();


        public void Insert(ServiceOrder serviceOrder)
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

