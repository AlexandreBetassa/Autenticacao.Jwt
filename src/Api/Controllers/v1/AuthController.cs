using Autenticacao.Jwt.Application.Commands.v1.GenerateToken;
using Autenticacao.Jwt.Domain.Enums.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Jwt.Controllers.v1
{
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthController : BaseController<AuthController>
    {
        public AuthController(IMediator mediator, ILoggerFactory loggerFactory) 
            : base(mediator, loggerFactory)
        {
        }

        [HttpPost("{typeUser}")]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenCommand request, RolesUserEnum typeUser)
        {
            request.TypeUser = typeUser;
            var token = await Mediator.Send(request);

            return Ok(token);
        }
    }
}