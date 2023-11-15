using LibraryProject.Application.Dto;
using LibraryProject.Domain.Entities;

namespace LibraryProject.Application.Interfaces
{
    public interface IBookService
    {
        Task<Book?> AddBookAsync(BookForAddingDto book, CancellationToken cancellationToken);
        List<Book> GetBooks();
        Book? GetBookById(int id);
        Book? GetBookByISBN(string  ISBN);
        Task<bool> DeleteBookAsync(BookDto book, CancellationToken cancellationToken);
        Task<bool> UpdateBookAsync(BookDto book, CancellationToken cancellationToken);
    }
}
