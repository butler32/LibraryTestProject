using LibraryProject.Application.Dto;
using LibraryProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto registrationDto, CancellationToken cancellationToken)
        {
            await _accountService.RegisterAsync(registrationDto, cancellationToken);

            return Ok(new { Success = "Success!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto, CancellationToken cancellationToken)
        {
            var result = await _accountService.LoginAsync(loginDto, cancellationToken);

            return Ok(new { Token = result });
        }
    }
}
