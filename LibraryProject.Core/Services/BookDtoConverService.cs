using LibraryProject.Application.Dto;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Entities;

namespace LibraryProject.Application.Services
{
    public class BookDtoConverService : IBookDtoConvertService
    {
        public BookDto BookToDto(Book book)
        {
            return new BookDto
            {
                Author = book.Author,
                Id = book.Id,
                Genre = book.Genre,
                DateBack = book.DateBack,
                DateTaken = book.DateTaken,
                Description = book.Description,
                ISBN = book.ISBN,
                Title = book.Title
            };
        }

        public Book DtoToBook(BookDto book)
        {
            return new Book
            {
                Author = book.Author,
                Id = book.Id,
                Genre = book.Genre,
                DateBack = book.DateBack,
                DateTaken = book.DateTaken,
                Description = book.Description,
                ISBN = book.ISBN,
                Title = book.Title
            };
        }

        public Book DtoToBook(BookForAddingDto book)
        {
            return new Book
            {
                Author = book.Author,
                Genre = book.Genre,
                DateBack = book.DateBack,
                DateTaken = book.DateTaken,
                Description = book.Description,
                ISBN = book.ISBN,
                Title = book.Title
            };
        }
    }
}
