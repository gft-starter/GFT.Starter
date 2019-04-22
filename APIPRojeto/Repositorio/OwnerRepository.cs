using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class OwnerRepository : BaseRepository

    {
        public IEnumerable<Owner> Get() => Db
            .Owners            
            .ToList();

        public Owner Find(Guid id) => Db
            .Owners  
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (Owner owners)
        {
            if (owners != null)
            {
                Db.Add(owners);
                Db.SaveChanges();

            }
        }




    }
}
