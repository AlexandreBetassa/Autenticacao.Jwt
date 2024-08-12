using Autenticacao.Jwt.Application.Commands.v1.Users.CreateUser;
using Autenticacao.Jwt.Application.Constants.v1;
using Autenticacao.Jwt.Filters.v1;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Jwt.Controllers.v1
{
    [Route("api/v1/users")]
    [ApiController]
    [ServiceFilter(typeof(FilterHeader))]
    public class UserController : BaseController<UserController>
    {
        public UserController(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        [HttpGet]
        [Authorize(Policy = AccessPolicies.Write)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Task.FromResult("Get write"));
        }

        [HttpGet("getUser")]
        [Authorize(Policy = AccessPolicies.Read)]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await Task.FromResult("Get read"));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }
    }
}