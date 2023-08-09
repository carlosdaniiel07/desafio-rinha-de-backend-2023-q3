using DesafioBackEnd.Interfaces.Services;
using StackExchange.Redis;
using System.Text.Json;

namespace DesafioBackEnd.Infrastructure.Services
{
    public class RedisService : ICacheService
    {
        private readonly IDatabase _database;

        public RedisService(IConfiguration configuration)
        {
            var connection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _database = connection.GetDatabase();
        }

        public async Task AddAsync<T>(string key, T value, TimeSpan ttl)
        {
            var json = JsonSerializer.Serialize(value, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

            await _database.StringSetAsync(key, json, ttl);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            return await _database.KeyExistsAsync(key);
        }

        public async Task<T> RetrieveAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);

            if (!value.HasValue)
                return default;

            return JsonSerializer.Deserialize<T>(value.ToString(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
