using Autenticacao.Jwt.Domain.Entities.v1;
using Autenticacao.Jwt.Domain.Interfaces.v1.Repositories;
using Dapper;
using System.Data;

namespace Autenticacao.Jwt.Infrastructure.Repositories.v1
{
    public class UserRepository(IDbConnection dbConnection) : IUserRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task CreateUserAsync(User user)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@NAME", user.Name, DbType.AnsiString, ParameterDirection.Input, user.Name.Length);
            parameters.Add("@PASSWORD", user.Password, DbType.AnsiString, ParameterDirection.Input, user.Password.Length);
            parameters.Add("@EMAIL", user.Email, DbType.AnsiString, ParameterDirection.Input, user.Email.Length);
            parameters.Add("@ROLE", user.Role, DbType.AnsiString, ParameterDirection.Input, user.Role.Length);

            var query = $"INSERT INTO AUTENTICACAO (NAME, PASSWORD, EMAIL, ROLE)" +
                            $"VALUES (@NAME, @PASSWORD, @EMAIL, @ROLE)";

            await _dbConnection.ExecuteScalarAsync(query, parameters);
        }

        public async Task<User> GetUser(string email)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@EMAIL", email, DbType.AnsiString, ParameterDirection.Input,email.Length);

            var query = $"SELECT NAME, PASSWORD, EMAIL, ROLE FROM AUTENTICACAO WHERE EMAIL = @EMAIL";

            return await _dbConnection.QueryFirstOrDefaultAsync<User>(query, parameters);
        }
    }
}