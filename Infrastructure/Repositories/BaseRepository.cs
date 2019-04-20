using Core.Settings;
using Infrastructure.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly LataVelhaContext Db;

        protected BaseRepository()
        {
            Db = new LataVelhaContext(new AppSettings
            {
                Database = new Database { ConnectionString = "Server=tcp:latavelha.database.windows.net,1433;Initial Catalog=LataVelha;Persist Security Info=False;User ID=fdario;Password=Gft@2019@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" }
            });
            Db.Database.Migrate();
        }
    }
}