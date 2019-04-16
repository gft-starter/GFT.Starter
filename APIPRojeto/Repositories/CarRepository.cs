using APIPRojeto.Models;
using APIPRojeto.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositories
{

    public class CarRepository
    {
        private readonly LataVelhaContext _db;

        public CarRepository()
        {
            _db = new LataVelhaContext();
        }

        public IEnumerable<Car> Get() => _db
            .Cars
            .Include(c => c.Owner)
            .ToList();

        public Car Find(Guid id) => _db
            .Cars
            .Include(c => c.Owner)
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add(Car car)
        {
            if (car != null)
            {
                _db.Add(car);
                _db.SaveChanges();
            }
        }

        public Car Remove(Car car)
        {
            if (car != null)
            {
                _db.Remove(car);
                _db.SaveChanges();
            }

            return car;
        }

        public Car Update(Car car)
        {
            if (car != null)
            {
                _db.Update(car);
                _db.SaveChanges();
            }

            return car;
        }
    }
}
