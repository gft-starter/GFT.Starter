using APIPRojeto.Repositorires.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
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
