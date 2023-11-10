using LibraryProject.Domain.Entities;

namespace LibraryProject.Domain.Interfaces
{
    public interface IBookRepository<T> : IBaseRepository<T>
        where T : Book
    {
        Task<T?> GetByISBN(string isbn);
        Task<List<T>> GetAll();

    }
}
