using LibraryProject.Application.Dto;
using LibraryProject.Domain.Entities;

namespace LibraryProject.Application.Interfaces
{
    public interface IBookDtoConvertService
    {
        Book DtoToBook(BookDto book);
        Book DtoToBook(BookForAddingDto book);
        BookDto BookToDto(Book book);

    }
}
