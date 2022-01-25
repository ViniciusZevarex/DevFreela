using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            if (user == null) return NotFound();

            return Ok(user);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand inputModel)
        {
            var id = await _mediator.Send(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }


        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(int id, [FromBody] LoginUserCommand login)
        {
            var loginToken = await _mediator.Send(login);

            if (loginToken == null) return BadRequest();

            return Ok(loginToken);
        }
    }
}
