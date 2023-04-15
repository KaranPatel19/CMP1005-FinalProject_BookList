using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BookListLibrary.Data;
using System.Threading.Tasks; 

namespace BookListLibrary.Services
{
    public class BookListService
    {
        private readonly IFirebaseClient _client;

        public BookListService()
        {
            _client = new FireSharp.FirebaseClient(FirebaseConfigHelper.Config);
        }
        public BookListService(IFirebaseClient client) 
        {
            _client = client;
        }

        public async Task AddBookAsync(BookList book)
        {
            PushResponse response = await _client.PushAsync("BookList/", book);
            int key = int.Parse(response.Result.name);
            book.Id = key;
            SetResponse setResponse = await _client.SetAsync($"BookList/{book.Id}", book);
        }
        public async Task<BookList> GetBookByIdAsync(int id)
        {
            FirebaseResponse response = await _client.GetAsync($"BookList/{id}");
            if (response.Body == "null")
            {
                return null;
            }

            var book = JsonConvert.DeserializeObject<BookList>(response.Body);
            return book;
        }

        public async Task<List<BookList>> GetAllBooksAsync()
        {
            FirebaseResponse response = await _client.GetAsync("BookList");
            if (response.Body == "null")
            {
                return new List<BookList>();
            }

            var data = JsonConvert.DeserializeObject<Dictionary<string, BookList>>(response.Body);
            var list = data.Values.ToList();

            return list;
        }

    }
}
