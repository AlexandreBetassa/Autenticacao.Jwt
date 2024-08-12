using Autenticacao.Jwt.Domain.Entities.v1;

namespace Autenticacao.Jwt.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email);
        Task CreateUserAsync(User user);
    }
}
