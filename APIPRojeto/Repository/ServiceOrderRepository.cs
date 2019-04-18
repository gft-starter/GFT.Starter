using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repository
{
    public class ServiceOrderRepository : BaseRepository
    {
        public IEnumerable<ServiceOrder> Get() => Db
              .ServiceOrders
              .Include(so => so.Car)
              .Include(so => so.Service)
              .ToList();

        public ServiceOrder Find(Guid id) => Db
            .ServiceOrders
            .Include(so => so.Car)
            .Include(so =>so.Service)
            .Where(so => so.Id == id)
            .FirstOrDefault();

        public ServiceOrder FindCar(Guid id) => Db
            .ServiceOrders
            .Include(so => so.Car)
            .Where(so => so.CarId == id)
            .FirstOrDefault();

        public ServiceOrder FindService(Guid id) => Db
            .ServiceOrders
            .Include(so => so.Service)
            .Where(so => so.ServiceId == id)
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
