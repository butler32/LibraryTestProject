using LibraryProject.Domain.Entities;
using LibraryProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected LibraryDbContext _context;

        public BaseRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T?> Get(int id)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(i => i.Id == id);
        }

        public async Task<bool> Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
