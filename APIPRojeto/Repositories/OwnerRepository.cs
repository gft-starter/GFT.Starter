using APIPRojeto.Models;
using APIPRojeto.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositories
{
    public class OwnerRepository : BaseRepository
    {
        
        public IEnumerable<Owner> Get() => Db.Owner.ToList();


        public Owner Find(Guid id) => Db.Owner.FirstOrDefault(x => x.Id == id);


        public void Insert(Owner owner)
        {
            if (owner != null)
            {
                Db.Add(owner);
                Db.SaveChanges();
            }
        }

        public Owner Remove(Owner owner)
        {
            if (owner != null)
            {
                Db.Remove(owner);
                Db.SaveChanges();
            }
            return owner;
        }

        public Owner Update(Owner owner)
        {
            if (owner != null)
            {
                Db.Update(owner);
                Db.SaveChanges();
            }
            return owner;
        }
    }
}
