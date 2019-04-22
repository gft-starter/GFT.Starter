using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    
    public class CarRepository : BaseRepository
    {
        
        public IEnumerable<Car> Get() =>Db.Cars.Include(c => c.Owner).ToList();
            

        public Car Find(Guid id) => Db.Cars.Include("Owner").FirstOrDefault(x => x.Id == id);


        public void Insert(Car car)
        {
            if(car != null)
            {
                Db.Add(car);
                Db.SaveChanges();
            }
        }

        public Car Remove(Car car)
        {
            if (car != null)
            {
                Db.Remove(car);
                Db.SaveChanges();
            }
            return car;
        }

        public Car Update(Car car)
        {
            if (car != null)
            {
                Db.Update(car);
                Db.SaveChanges();
            }
            return car;
        }
    }

    
}

