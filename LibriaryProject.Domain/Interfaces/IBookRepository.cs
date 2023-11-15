using LibraryProject.Domain.Entities;

namespace LibraryProject.Domain.Interfaces
{
    public interface IBookRepository<T> : IBaseRepository<T>
        where T : Book
    {
        T? GetByISBN(string isbn);
        List<T> GetAll();

    }
}
