using Microsoft.AspNetCore.Mvc;
using BankApp.Api.Interfaces;
using BankApp.Api.DTOs;
using BankApp.Api.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BankApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            try
            {
                await _service.Register(dto);
                return StatusCode(201);
            }
            catch (UserAlreadyExistsException)
            {
                return Conflict("User already exists");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            try
            {
                var result = await _service.Login(dto);
                return Ok(result);
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized("Login or password false");
            }
        }
    }
}
