namespace Autenticacao.Jwt.Domain.Interfaces.Services.v1
{
    public interface IRedisService
    {
        Task CreateAsync(string key, object data, int expirationInMinutes = 15);
        Task<string> GetKey(string key);
    }
}
