using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week6Assignment.DAL;
using Week6Assignment.Repositary;
using Week6Assignment.Services;

namespace Week6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IAssetService<Book> _bookService;

        public BooksController(IAssetService<Book> bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsset();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.SearchAsset(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book object is null");

            }

            var addedBook = await _bookService.AddAsset(book);
            return CreatedAtAction(nameof(GetBook), new { id = addedBook.Id }, addedBook);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest("Invalid book object");
            }

            var existingBook = await _bookService.SearchAsset(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            await _bookService.UpdateAsset(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.SearchAsset(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookService.DeleteAsset(book);
            return NoContent();
        }
    }
}
