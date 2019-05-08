using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Repository.Contracts;
using Infrastructure.Configuration;

namespace Infrastructure.Repository
{
    public class CarRepository : IReadOnlyRepository<Car>, IWriteRepository<Car>
    {
        private readonly LataVelhaContext _db;

        public int Count => throw new NotImplementedException();

        public CarRepository(LataVelhaContext db)
        {
            _db = db;
        }

        public CarRepository(){}

        public IEnumerable<Car> Get() => _db
            .Cars.OfType<Car>()
            .Include(c => c.Owner)
            .ToList();

        public Car Find(Guid id) => _db
            .Cars.OfType<Car>()
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

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