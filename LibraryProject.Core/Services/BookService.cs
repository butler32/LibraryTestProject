using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Entities;
using LibraryProject.Domain.Exceptions;
using LibraryProject.Domain.Interfaces;

namespace LibraryProject.Application.Services
{
    public class BookService : IBookService
    {
        private IBookRepository<Book> _bookRepository;

        public BookService(IBookRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book?> AddBook(Book book)
        {
            if (await _bookRepository.Get(book.Id) == null)
            {
                return await _bookRepository.Add(book);
            }
            throw new EntityAlreadyExistsException("Book with this id already exist");
        }

        public async Task<bool> DeleteBook(Book book)
        {
            if (await _bookRepository.Get(book.Id) != null)
            {
                return await _bookRepository.Delete(book);
            }
            throw new EntityNotFoundException("Cannot found book to delete");
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var existingBook = await _bookRepository.Get(book.Id);

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
                return await _bookRepository.Update(book);
            }

            throw new InvalidOperationException();
        }

        public async Task<Book?> GetBookById(int id)
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                throw new EntityNotFoundException($"Cannot find book with {id} id");
            }
            return book;
        }

        public async Task<Book?> GetBookByISBN(string ISBN)
        {
            var book = await _bookRepository.GetByISBN(ISBN);
            if (book == null)
            {
                throw new EntityNotFoundException($"Cannot find book with {ISBN} ISBN");
            }
            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await _bookRepository.GetAll();
            if (books == null)
            {
                throw new EntityNotFoundException("Library is empty");
            }
            return books;
        }
    }
}
