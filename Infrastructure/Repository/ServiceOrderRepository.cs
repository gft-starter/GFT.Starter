using APIPRojeto.Models;
using APIPRojeto.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repository
{
    public class ServiceOrderRepository : BaseRepository
    {
        public IEnumerable<ServiceOrder> Get() => Db
         .ServiceOrders
         .Include(so => so.Car)
         .Include(so => so.Car.Owner)
         .Include(so => so.Service)
         .ToList();

        public ServiceOrder Find(Guid id) => Db
            .ServiceOrders
            .Include(so => so.Car)
            .Include(so => so.Car.Owner)
            .Include(so => so.Service)
            .FirstOrDefault(so => so.Id == id);

        public ServiceOrder FindCar(Guid id) => Db
            .ServiceOrders
            .Include(so => so.Car)
            .FirstOrDefault(so => so.CarId == id);

        public ServiceOrder FindService(Guid id) => Db
            .ServiceOrders
            .Include(so => so.Service)
            .Include(so => so.Car)
            .FirstOrDefault(so => so.ServiceId == id);

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
