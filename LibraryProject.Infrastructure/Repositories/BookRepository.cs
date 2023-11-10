using LibraryProject.Domain.Entities;
using LibraryProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infrastructure.Repositories
{
    public class BookRepository<T> : BaseRepository<T>, IBookRepository<T>
        where T : Book
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }


        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T?> GetByISBN(string isbn)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(i => i.ISBN == isbn);
        }

    }
}
