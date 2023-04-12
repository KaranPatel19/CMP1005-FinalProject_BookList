using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BookListLibrary.Data;
namespace BookListLibrary.Services;

public class BookListService
{
    private readonly IFirebaseClient _client;

    public BookListService()
    {
        _client = new FireSharp.FirebaseClient(FirebaseConfigHelper.Config);
    }

    public Task<List<BookList>> GetAllBooksAsync()
    {
        FirebaseResponse response = _client.Get("BookList");
        dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
        var list = new List<BookList>();
        foreach (var item in data)
        {
            if (item != null)
            {
                var recipe = JsonConvert.DeserializeObject<BookList>(item.ToString());
                list.Add(recipe);
            }
        }

        return Task.FromResult(list);
    }
}