using LibraryProject.Application.Dto;
using Microsoft.AspNetCore.Identity;

namespace LibraryProject.Application.Interfaces
{
    public interface IAccountService
    {
        Task<string?> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken);
        Task RegisterAsync(RegistrationDto registrationDto, CancellationToken cancellationToken);
    }
}
