using LibraryProject.Application.Interfaces;
using LibraryProject.Application.Services;
using LibraryProject.Domain.Interfaces;
using LibraryProject.Infrastructure;
using LibraryProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryProject.API.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection DISet(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserStore<IdentityUser<int>>, UserStore<IdentityUser<int>, IdentityRole<int>, LibraryDbContext, int>>();
            services.AddScoped<IRoleStore<IdentityRole<int>>, RoleStore<IdentityRole<int>, LibraryDbContext, int>>();
            
            services.AddScoped<IBookService, BookService>();
            services.AddScoped(typeof(IBookRepository<>), typeof(BookRepository<>));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDataBaseSeeder, DataBaseSeeder>();
            services.AddScoped<IBookDtoConvertService, BookDtoConverService>();

            services.AddScoped<UserManager<IdentityUser<int>>>();
            services.AddScoped<SignInManager<IdentityUser<int>>>();

            return services;
        }
    }
}
