using Application;
using Application.Book.Dto;
using Application.Book.Ports;
using Application.Book.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookDto dto)
        {
            var request = new CreateBookRequest
            {
                Data = dto
            };

            var res = await _bookManager.CreateAsync(request);

            if (res.Success) return Created("", res.Data);

            return res.ErrorCode switch
            {
                ErrorCode.BOOK_INVALID_NAME => BadRequest(res),
                ErrorCode.BOOK_INVALID_AUTHOR => BadRequest(res),
                ErrorCode.BOOK_INVALID_EDITION => BadRequest(res),
                ErrorCode.BOOK_INVALID_BIO => BadRequest(res),
                ErrorCode.BOOK_INVALID_PUBLISING_COMPANY => BadRequest(res),
                ErrorCode.BOOK_INVALID_PAGE => BadRequest(res),
                _ => BadRequest(500)
            };
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] BookDto dto,
            [FromQuery] int id)
        {
            var request = new UpdateBookRequest
            {
                Data = dto,
                Id = id
            };

            var res = await _bookManager.UpdateBook(request);

            if (res.Success) return Ok(res.Data);

            return res.ErrorCode switch
            {
                ErrorCode.BOOK_INVALID_NAME => BadRequest(res),
                ErrorCode.BOOK_INVALID_AUTHOR => BadRequest(res),
                ErrorCode.BOOK_INVALID_EDITION => BadRequest(res),
                ErrorCode.BOOK_INVALID_BIO => BadRequest(res),
                ErrorCode.BOOK_INVALID_PUBLISING_COMPANY => BadRequest(res),
                ErrorCode.BOOK_INVALID_PAGE => BadRequest(res),
                _ => BadRequest(500)
            };
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var books = await _bookManager
                .GetBooksAsync();

            return Ok(books.Books);
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetById(int id)
        {
            var book = await _bookManager
                .GetBookByIdAsync(id);

            return Ok(book.Data);
        }
    }
}
