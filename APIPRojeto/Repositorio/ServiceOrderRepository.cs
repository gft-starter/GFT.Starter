using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class ServiceOrderRepository : BaseRepository

    {
        

        public IEnumerable<ServiceOrder> Get() => Db
            .ServiceOrders
            .Include(c => c.Car)
            .Include(c => c.Car.Owner)
            .Include(c => c.Service)
            .ToList();

        public ServiceOrder Find(Guid id) => Db
            .ServiceOrders
            .Include(c => c.Car)
            .Include(c => c.Car.Owner)
            .Include(c => c.Service)
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (ServiceOrder ServiceOrders)
        {
            if (ServiceOrders != null)
            {
                Db.Add(ServiceOrders);
                Db.SaveChanges();

            }
        }




    }
}
