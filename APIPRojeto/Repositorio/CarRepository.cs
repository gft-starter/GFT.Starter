using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
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
            .Include ("Owner")
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (Car car)
        {
            if (car != null)
            {
                _db.Add(car);
                _db.SaveChanges();

            }
        }




    }
}
