using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class BaseRepository
        
    {
        protected readonly LataVelhaContext Db;

         protected BaseRepository()
        {
            Db = new LataVelhaContext();
            Db.Database.Migrate();
        }




    }
}
