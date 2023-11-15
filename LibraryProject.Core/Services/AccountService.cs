using LibraryProject.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using LibraryProject.Domain.Exceptions;
using LibraryProject.Domain.Enums;
using LibraryProject.Application.Dto;

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

        public async Task<string?> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user == null)
            {
                throw new NoSuchUserException("Invalid username");
            }

            if (await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenService.GenerateToken(user, roles);

                return token;
            }

            throw new InvalidOperationException("Invalid password");
        }

        public async Task RegisterAsync(RegistrationDto registrationDto, CancellationToken cancellationToken)
        {
            var user = new IdentityUser<int> { UserName = registrationDto.Username };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RolesEnum.UserRole.ToString());
            }
            else
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }
        }
    }
}
