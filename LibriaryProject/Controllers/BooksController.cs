using LibraryProject.Application.Dto;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Entities;
using LibraryProject.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _bookService.GetBooks();

            return Ok(books);
        }

        [Authorize(Roles = nameof(RolesEnum.UserRole))]
        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.GetBookById(id);

            return Ok(book);
        }

        [Authorize(Roles = nameof(RolesEnum.UserRole))]
        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody] BookForAddingDto book, CancellationToken cancellationToken)
        {
            await _bookService.AddBookAsync(book, cancellationToken);

            return Ok();
        }

        [Authorize(Roles = nameof(RolesEnum.UserRole))]
        [HttpGet("isbn/{isbn}")]
        public ActionResult<Book> GetByISBN([FromRoute]string isbn)
        {
            var book = _bookService.GetBookByISBN(isbn);

            return Ok(book);
        }

        [Authorize(Roles = nameof(RolesEnum.AdminRole))]
        [HttpPut]
        public async Task<ActionResult> EditAsync([FromBody] BookDto book, CancellationToken cancellationToken)
        {
            await _bookService.UpdateBookAsync(book, cancellationToken);

            return Ok();
        }

        [Authorize(Roles = nameof(RolesEnum.AdminRole))]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] BookDto book, CancellationToken cancellationToken)
        {
            await _bookService.DeleteBookAsync(book, cancellationToken);

            return Ok();
        }
    }
}
