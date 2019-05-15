namespace Application.Factories.Interfaces
{
    public interface IFactory<T>
    {
        T Create();
    }
}
