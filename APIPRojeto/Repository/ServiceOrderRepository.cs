using APIPRojeto.Models;
using APIPRojeto.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repository
{
    public class ServiceOrderRepository
    {
        private readonly LataVelhaContext _db;

        public ServiceOrderRepository()
        {
            _db = new LataVelhaContext();
        }

        public IEnumerable<ServiceOrder> Get() => _db
            .ServiceOrders
            .Include(so => so.Car)
            .Include(so => so.Service)
            .ToList();

        public ServiceOrder Find(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Car)
            .Include(so =>so.Service)
            .Where(so => so.Id == id)
            .FirstOrDefault();

        public ServiceOrder FindCar(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Car)
            .Where(so => so.CarId == id)
            .FirstOrDefault();

        public ServiceOrder FindService(Guid id) => _db
            .ServiceOrders
            .Include(so => so.Service)
            .Where(so => so.ServiceId == id)
            .FirstOrDefault();

        public void Add(ServiceOrder serviceOrder)
        {
            if(serviceOrder != null)
            {
                _db.Add(serviceOrder);
                _db.SaveChanges();
            }
        }

        public ServiceOrder Remove(ServiceOrder serviceOrder)
        {
            if(serviceOrder != null)
            {
                _db.Remove(serviceOrder);
                _db.SaveChanges();
            }
            return serviceOrder;
        }
        public ServiceOrder Update(ServiceOrder serviceOrder)
        {
            if(serviceOrder != null)
            {
                _db.Update(serviceOrder);
                _db.SaveChanges();
            }
            return serviceOrder;
        }
    }

}
