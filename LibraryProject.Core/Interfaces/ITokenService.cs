using Microsoft.AspNetCore.Identity;

namespace LibraryProject.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser<int> user, IList<string> roles);
    }
}
