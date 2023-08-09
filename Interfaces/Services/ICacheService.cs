namespace DesafioBackEnd.Interfaces.Services
{
    public interface ICacheService
    {
        Task AddAsync<T>(string key, T value, TimeSpan ttl);
        Task<T> RetrieveAsync<T>(string key);
        Task<bool> ExistsAsync(string key);
    }
}
