using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Configuration;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class CarRepository : IReadOnlyRepository<Car>, IWriteRepository<Car>
    {
        private readonly LataVelhaContext _db;

        public CarRepository(LataVelhaContext db)
        {
            _db = db;
        }

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