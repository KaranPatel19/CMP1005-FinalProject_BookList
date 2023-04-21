using Microsoft.AspNetCore.Mvc;
using BookListLibrary.Data;
using BookListLibrary.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookListController : ControllerBase
    {
        private readonly BookListService _bookListService;

        public BookListController(BookListService bookListService)
        {
            _bookListService = bookListService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookList>>> GetAllBooksAsync()
        {
            var books = await _bookListService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody] BookList book)
        {
            await _bookListService.AddBookAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> SaveBookAsync(int id, [FromBody] BookList book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookListService.SaveBookAsync(book.Id, book.Title, book.Author, book.Genre, book.Description);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(int id)
        {
            await _bookListService.DeleteBookAsync(id);
            return Ok();
        }
    }
}