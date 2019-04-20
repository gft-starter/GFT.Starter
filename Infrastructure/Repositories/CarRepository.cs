using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CarRepository : BaseRepository
    {
        public IEnumerable<Car> Get() => Db
            .Cars
            .Include(c => c.Owner)
            .ToList();

        public Car Find(Guid id) => Db
            .Cars
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

        public void Add(Car car)
        {
            if (car != null)
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