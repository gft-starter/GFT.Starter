namespace Core.Settings
{
    public class AppSettings
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string ConnectionString { get; set; }
    }
}