using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
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

        public IEnumerable<Car> Get() => _db.Cars.ToList();






    }
}
