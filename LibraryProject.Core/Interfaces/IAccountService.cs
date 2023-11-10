using Microsoft.AspNetCore.Identity;

namespace LibraryProject.Application.Interfaces
{
    public interface IAccountService
    {
        Task<string?> LoginAsync(string username, string password);
        Task<IdentityResult> RegisterAsync(string username, string password);
    }
}
