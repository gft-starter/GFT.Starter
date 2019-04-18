using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
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
            .Include(c => c.Car)
            .Include(c => c.Car.Owner)
            .Include(c => c.Service)
            .ToList();

        public ServiceOrder Find(Guid id) => _db
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
                _db.Add(ServiceOrders);
                _db.SaveChanges();

            }
        }




    }
}
