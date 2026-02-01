namespace Pustok.DataAccess.Abstractions
{
    public interface IContextInitializer
    {
        Task InitDatabaseAsync();
    }
}
