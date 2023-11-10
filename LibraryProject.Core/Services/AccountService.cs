using LibraryProject.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using LibraryProject.Domain.Exceptions;

namespace LibraryProject.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public AccountService(UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;

        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new NoSuchUserException("Invalid username");
            }

            if (await _userManager.CheckPasswordAsync(user, password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenService.GenerateToken(user, roles);

                return token;
            }

            throw new InvalidOperationException();
        }

        public async Task<IdentityResult> RegisterAsync(string username, string password)
        {
            var user = new IdentityUser<int> { UserName = username };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "UserRole");
            }

            return result;
        }
    }
}
