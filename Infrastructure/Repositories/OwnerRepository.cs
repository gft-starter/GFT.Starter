using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Configuration;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class OwnerRepository : IReadOnlyRepository<Owner>, IWriteRepository<Owner>
    {
        private readonly LataVelhaContext _db;

        public OwnerRepository(LataVelhaContext db)
        {
            _db = db;
        }

        public IEnumerable<Owner> Get() => _db
            .Owners
            .ToList();

        public Owner Find(Guid id) => _db
            .Owners
            .Include(o => o.Id == id)
            .FirstOrDefault();

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