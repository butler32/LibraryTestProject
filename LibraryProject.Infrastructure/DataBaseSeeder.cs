using LibraryProject.Domain.Entities;
using LibraryProject.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

namespace LibraryProject.Infrastructure
{
    public class DataBaseSeeder : IDataBaseSeeder
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly LibraryDbContext _context;
        public DataBaseSeeder(LibraryDbContext applicationDbContext, UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
            _context = applicationDbContext;
        }

        public async Task Seed(IApplicationBuilder app)
        {
            _context.Database.EnsureCreated();

            if (!_context.Books.Any())
            {
                List<Book> books = new List<Book>();

                books.Add(new Book
                {
                    Author = "Andrzej Sapkowski",
                    Title = "The last wish",
                    Description = "The Last Wish is a collection of six short stories surrounding The Witcher, Geralt of Rivia, and they are intersected by a frame story.",
                    Genre = "Fantasy",
                    ISBN = "9780316029186",
                    DateTaken = new DateTime(2022, 12, 1).ToUniversalTime(),
                    DateBack = new DateTime(2023, 1, 26).ToUniversalTime(),
                });

                books.Add(new Book
                {
                    Author = "Andrzej Sapkowski",
                    Title = "Sword of Destiny",
                    Description = "Sword of Destiny is a collection of six short stories surrounding The Witcher, Geralt of Rivia, and they are intersected by a frame story.",
                    Genre = "Fantasy",
                    ISBN = "9784316526116",
                    DateTaken = new DateTime(2023, 1, 23).ToUniversalTime(),
                    DateBack = new DateTime(2023, 2, 26).ToUniversalTime(),
                });


                foreach (var book in books)
                {
                    await _context.Books.AddAsync(book);
                }

                var user = new IdentityUser<int> { UserName = "admin" };
                var result = await _userManager.CreateAsync(user, "A123a_");
                await _userManager.AddToRoleAsync(user, RolesEnum.AdminRole.ToString());
                await _userManager.AddToRoleAsync(user, RolesEnum.UserRole.ToString());
                
                await _context.SaveChangesAsync();
            }
        }
    }
}
