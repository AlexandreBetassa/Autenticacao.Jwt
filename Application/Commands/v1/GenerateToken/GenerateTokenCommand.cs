using Autenticacao.Jwt.Domain.Enums.v1;
using MediatR;
using System.Text.Json.Serialization;

namespace Autenticacao.Jwt.Application.Commands.v1.GenerateToken
{
    public class GenerateTokenCommand : IRequest<string>
    {
        [JsonIgnore]
        public RolesUserEnum TypeUser { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}