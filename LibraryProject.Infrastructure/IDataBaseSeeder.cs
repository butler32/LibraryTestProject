using Microsoft.AspNetCore.Builder;

namespace LibraryProject.Infrastructure
{
    public interface IDataBaseSeeder
    {
        Task Seed(IApplicationBuilder app);
    }
}
