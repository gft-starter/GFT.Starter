using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
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
