using Microsoft.AspNetCore.Identity;

namespace LibraryProject.API.Extensions
{
    public static class RolesExtension
    {
        public static async Task<WebApplication> RolesSetAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

                    var roles = new List<string> { "UserRole", "AdminRole" };
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole<int> { Name = role });
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            return app;
        }
    }
}
