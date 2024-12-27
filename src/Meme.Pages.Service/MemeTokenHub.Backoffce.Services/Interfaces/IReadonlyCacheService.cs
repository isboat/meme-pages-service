namespace MemeTokenHub.Backoffce.Services.Interfaces
{
    public interface IReadonlyCacheService
    {
        Task<List<T>> GetItemsFromList<T>();
    }
}
