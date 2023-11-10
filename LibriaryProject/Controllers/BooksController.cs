using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _bookService.GetBooks();
            return Ok(books);
        }

        [Authorize(Roles = "UserRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _bookService.GetBookById(id);
            return Ok(book);
        }

        [Authorize(Roles = "UserRole")]
        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] Book book)
        {
            await _bookService.AddBook(book);
            return Ok();
        }

        [Authorize(Roles = "UserRole")]
        [HttpGet("isbn/{isbn}")]
        public async Task<ActionResult<Book>> GetByISBN([FromRoute]string isbn)
        {
            var book = await _bookService.GetBookByISBN(isbn);
            return Ok(book);
        }

        [Authorize(Roles = "AdminRole")]
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] Book book)
        {
            await _bookService.UpdateBook(book);
            return Ok();
        }

        [Authorize(Roles = "AdminRole")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Book book)
        {
            await _bookService.DeleteBook(book);
            return Ok();
        }
    }
}
