using BSol.API.CQRS.Command.Auth;
using BSol.API.DTOs.Auth;
using BSol.API.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BSol.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // REGISTER USER
        [HttpPost]
        [Route("/auth/rgister/user")]
        public async Task<IActionResult> Register([FromBody] RequestRegister request)
        {
            if(request == null)
            {
                return BadRequest(new NResponse
                {
                    Code = 0,
                    Message = "Null Request"
                });
            }
            try
            {
                return Ok(await _mediator.Send(new RegisterUserCommand(request)));
            }
            catch (Exception ex)
            {
                return BadRequest(new NResponse
                {
                    Code = 0,
                    Message = $"==> {ex.Message}"
                });
            }
        }


    }
}
