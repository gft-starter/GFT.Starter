namespace GFT.Starter.Infrastructure.Repositories
{
    public interface IWriteRepository<T>
    {
        void Add(T car);
        T Remove(T car);
        T Update(T car);
    }
}