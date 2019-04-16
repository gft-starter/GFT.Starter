using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    public class OwnerRepository
    {
        private readonly LataVelhaContext _db;
        public OwnerRepository()
        {
            _db = new LataVelhaContext();

        }
        public IEnumerable<Owner> Get() => _db.Owner.ToList();


        public Owner Find(Guid id) => _db.Owner.Where(x => x.Id == id).FirstOrDefault();


        public void Insert(Owner owner)
        {
            if (owner != null)
            {
                _db.Add(owner);
                _db.SaveChanges();
            }
        }

        public Owner Remove(Owner owner)
        {
            if (owner != null)
            {
                _db.Remove(owner);
                _db.SaveChanges();
            }
            return owner;
        }

        public Owner Update(Owner owner)
        {
            if (owner != null)
            {
                _db.Update(owner);
                _db.SaveChanges();
            }
            return owner;
        }
    }
}
