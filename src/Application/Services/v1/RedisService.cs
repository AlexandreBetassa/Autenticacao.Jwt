using Autenticacao.Jwt.CrossCutting.Configurations.v1;
using Autenticacao.Jwt.Domain.Interfaces.v1.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Autenticacao.Jwt.Application.Services.v1
{
    public class RedisService(IDistributedCache cache, AppsettingsConfigurations appsettingsConfiguration) : IRedisService
    {
        private IDistributedCache _cache { get; set; } = cache;
        private AppsettingsConfigurations _appsettingsConfiguration {  get; set; } = appsettingsConfiguration; 

        public async Task CreateAsync(string key, object data, int expirationInMinutes = 15)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(_appsettingsConfiguration.RedisConfiguration.ExpirationInMinutes)
            };

            var dataJson = JsonSerializer.Serialize(data);

            await _cache.SetStringAsync(key, dataJson, cacheOptions);
        }

        public async Task<string> GetKey(string key)
        {
            return await _cache.GetStringAsync(key);
        }
    }
}