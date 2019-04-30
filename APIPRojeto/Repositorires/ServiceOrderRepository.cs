﻿using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    public class ServiceOrderRepository : BaseRepository
    {
        public IEnumerable<ServiceOrder> Get() => Db.ServiceOrder.Include("Service").Include("Car").ToList();


        public ServiceOrder Find(Guid id) => Db.ServiceOrder.Include("Service").Include("Car").FirstOrDefault(x => x.Id == id);


        public void Insert(ServiceOrder serviceOrder)
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
