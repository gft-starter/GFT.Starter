﻿using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class OwnerRepository
        
    {
        private readonly LataVelhaContext _db;

        public OwnerRepository()
        {
            _db = new LataVelhaContext();
        }

        public IEnumerable<Owner> Get() => _db
            .Owners            
            .ToList();

        public Owner Find(Guid id) => _db
            .Owners  
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (Owner owners)
        {
            if (owners != null)
            {
                _db.Add(owners);
                _db.SaveChanges();

            }
        }




    }
}
