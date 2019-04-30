using GFT.Starter.Core.Settings;
using GFT.Starter.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly LataVelhaContext Db;

        protected BaseRepository()
        {
            Db = new LataVelhaContext(new AppSettings
            {
                Database = new Database { ConnectionString = "Server=BRPC003801\\SQLEXPRESS, Database=Teste , TrustServerCertificate=True;" }
            });
            Db.Database.Migrate();
        }
    }
}