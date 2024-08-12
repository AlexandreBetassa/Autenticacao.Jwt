using Autenticacao.Jwt.Domain.Interfaces.Repositories;

namespace Autenticacao.Jwt.Domain.Interfaces.Patterns
{
    public interface IUnityOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
