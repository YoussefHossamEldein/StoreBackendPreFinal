using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Auth;
using Store.Application.Features.Auth.Commands;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _mediator.Send(new LoginCommand(dto));
            if (result == null)
                return Unauthorized(new { message = "Invalid email or password" });
            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try{
                var result = await _mediator.Send(new RegisterCommand(dto));
                return Ok(result);
                }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
