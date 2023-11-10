using LibraryProject.API.Models;
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
        public async Task<IActionResult> Register([FromBody] AccountModel model)
        {
            var result = await _accountService.RegisterAsync(model.Username, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { Success = "Success!" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountModel model)
        {
            var result = await _accountService.LoginAsync(model.Username, model.Password);

            if (result != null)
            {
                return Ok(new { Token = result });
            }

            return BadRequest(new { Message = "Invalid username or password" });
        }
    }
}
