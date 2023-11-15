using LibraryProject.Application.Dto;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Entities;
using LibraryProject.Domain.Exceptions;
using LibraryProject.Domain.Interfaces;

namespace LibraryProject.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly IBookDtoConvertService _bookDtoConvertService;

        public BookService(IBookRepository<Book> bookRepository, IBookDtoConvertService bookDtoConvertService)
        {
            _bookRepository = bookRepository;
            _bookDtoConvertService = bookDtoConvertService;
        }

        public async Task<Book?> AddBookAsync(BookForAddingDto book, CancellationToken cancellationToken)
        {
            return await _bookRepository.AddAsync(_bookDtoConvertService.DtoToBook(book), cancellationToken);
        }

        public async Task<bool> DeleteBookAsync(BookDto book, CancellationToken cancellationToken)
        {
            if (_bookRepository.Get(book.Id) != null)
            {
                return await _bookRepository.DeleteAsync(_bookDtoConvertService.DtoToBook(book), cancellationToken);
            }

            throw new EntityNotFoundException("Cannot found book to delete");
        }

        public async Task<bool> UpdateBookAsync(BookDto book, CancellationToken cancellationToken)
        {
            var existingBook = _bookRepository.Get(book.Id);

            if (existingBook == null)
            {
                throw new EntityNotFoundException("Cannot found book to update");
            }

            if (existingBook!= null && existingBook.Equals(book))
            {
                throw new EntityAlreadyExistsException("Change something to update");
            }

            if (existingBook != null)
            {
                return await _bookRepository.UpdateAsync(_bookDtoConvertService.DtoToBook(book), cancellationToken);
            }

            throw new InvalidOperationException();
        }

        public Book? GetBookById(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
            {
                throw new EntityNotFoundException($"Cannot find book with {id} id");
            }

            return book;
        }

        public Book? GetBookByISBN(string ISBN)
        {
            var book = _bookRepository.GetByISBN(ISBN);
            if (book == null)
            {
                throw new EntityNotFoundException($"Cannot find book with {ISBN} ISBN");
            }

            return book;
        }

        public List<Book> GetBooks()
        {
            var books = _bookRepository.GetAll();
            if (books == null)
            {
                throw new EntityNotFoundException("Library is empty");
            }

            return books;
        }
    }
}
