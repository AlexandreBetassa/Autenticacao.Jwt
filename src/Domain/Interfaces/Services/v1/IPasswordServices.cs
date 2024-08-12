namespace Autenticacao.Jwt.Domain.Interfaces.Services.v1
{
    public interface IPasswordServices<T> where T : class
    {
        string HashPassword(T user, string password);
        bool VerifyPassword(T user, string hashedPassword, string password);
    }
}