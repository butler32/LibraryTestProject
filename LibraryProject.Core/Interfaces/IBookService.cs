using LibraryProject.Domain.Entities;

namespace LibraryProject.Application.Interfaces
{
    public interface IBookService
    {
        Task<Book?> AddBook(Book book);
        Task<List<Book>> GetBooks();
        Task<Book?> GetBookById(int id);
        Task<Book?> GetBookByISBN(string  ISBN);
        Task<bool> DeleteBook(Book book);
        Task<bool> UpdateBook(Book book);
    }
}
