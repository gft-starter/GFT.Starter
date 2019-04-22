using APIPRojeto.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositories
{
    public class BaseRepository
    {
        protected readonly LataNovaContext Db;

        protected BaseRepository()
        {
            Db = new LataNovaContext();
            Db.Database.Migrate();
        }
    }
}