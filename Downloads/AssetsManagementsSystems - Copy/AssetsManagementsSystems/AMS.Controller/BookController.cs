using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetsManagementSystems.Api.Books;
using AssetsManagementsSystems.DAL;
using AMS.Logic.BookService;
using Microsoft.Extensions.Logging;
using AMS.Api.Response;
using Microsoft.AspNetCore.Authorization;

namespace AssetsManagementsSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("GetAllBooks")]
        public async Task<BookResponse>GetAllBooks()
        {
            try
            {
                _logger.LogInformation("GetAllBooks method executed.");
                var books = await _bookService.GetAllAsset();
                return new BookResponse { StatusCode = 200, StatusMessage = "Success", Data = books };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all books.");
                return new BookResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }


        [HttpGet("{id}")]
        public async Task<BookResponse> GetBook(int id)
        {
            try
            {
                _logger.LogInformation("GetBook method executed for id: {Id}.", id);
                var book = await _bookService.SearchAsset(id);
                if (book == null)
                {
                    _logger.LogInformation("Book with id {Id} not found.", id);
                    return new BookResponse { StatusCode = 404, StatusMessage = "Book not found", Data = null };
                }

                var bookResponse = new BookResponse
                {
                    SerialNumber = book.SerialNumber,
                    Name = book.Name,
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    Details = book.Details
                };

                return new BookResponse { StatusCode = 200, StatusMessage = "Success"};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the book with id: {Id}.", id);
                return new BookResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }

        }

        //[HttpGet("{id}")]
        //public async Task<CustomResponse<BookResponse>> GetBook(int id)
        //{

        //    _logger.LogInformation("GetBook method executed for id: {Id}.", id);
        //    var book = await _bookService.SearchAsset(id);
        //    if (book == null)
        //    {
        //        _logger.LogInformation("Book with id {Id} not found.", id);
        //        return new CustomResponse<BookResponse> { StatusCode = 404, StatusMessage = "Book not found", Data = null };
        //    }

        //    var bookResponse = new BookResponse
        //    {
        //        SerialNumber = book.SerialNumber,
        //        Name = book.Name,
        //        Author = book.Author,
        //        Id = book.Id,
        //        Title = book.Title,
        //        Details = book.Details
        //    };

        //    return new CustomResponse<BookResponse> { StatusCode = 200, StatusMessage = "Success", Data = bookResponse };


        //}

        [HttpPost("AddBook")]
        public async Task<BookResponse> AddBook(BookRequest bookRequest)
        {
            try
            {
                _logger.LogInformation("AddBook method executed.");
                var addedBook = await _bookService.AddAsset(bookRequest);
                return new BookResponse { StatusCode = 200, StatusMessage = "Asset Added Successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a book.");
                return new BookResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpPut("{id}")]
        public async Task<BookResponse> UpdateBook(int id, BookRequest bookRequest)
        {
            try
            {
                _logger.LogInformation("UpdateBook method executed for id: {Id}.", id);
                await _bookService.UpdateAsset(id, bookRequest);
                return new BookResponse { StatusCode = 204, StatusMessage = "Book updated successfully", Data = null };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book with id: {Id}.", id);
                return new BookResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpDelete("{id}")]
        public async Task<BookResponse> DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation("DeleteBook method executed for id: {Id}.", id);
                await _bookService.DeleteAssetById(id);
                return new BookResponse { StatusCode = 204, StatusMessage = "Book deleted successfully", Data = null };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book with id: {Id}.", id);
                return new BookResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }
    }
}
