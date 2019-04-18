using APIPRojeto.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace APIPRojeto.Repository
{
    public class BaseRepository
    {
        protected readonly LataVelhaContext Db;

        public BaseRepository()
        {
            Db = new LataVelhaContext();
            Db.Database.Migrate();
        }
    }
}