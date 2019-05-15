using Core.Models;
using Infrastructure.Configuration;
using Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class OwnerRepository : IReadOnlyRepository<Owner>, IWriteRepository<Owner>
    {
        private readonly LataNovaContext _db;

        public OwnerRepository(LataNovaContext db)
        {
            _db = db;
        }

        public IEnumerable<Owner> Get() => _db
            .Owners
            .ToList();

        public Owner Find(Guid id) => _db
            .Owners
            .FirstOrDefault(o => o.Id == id);

        public void Add(Owner owner)
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
