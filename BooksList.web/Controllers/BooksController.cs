using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookList.Library;
using BookList.Tests;
namespace BookList.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookListService _bookListService;

        public BooksController(BookListService bookListService)
        {
            _bookListService = bookListService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookListService>> Get() => (IEnumerable<BookListService>)await BookListService.GetbookAsync();
    }
}
