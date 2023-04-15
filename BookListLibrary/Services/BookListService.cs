using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BookListLibrary.Exceptions;
using BookListLibrary.Data;
using System.ComponentModel.DataAnnotations;

namespace BookListLibrary.Services;

public class BookListService
{
    private readonly IFirebaseClient _client;

    public BookListService()
    {
        _client = new FireSharp.FirebaseClient(FirebaseConfigHelper.Config);
    }
   
   public async Task AddBookAsync(BookList book)
    {
        PushResponse response = await _client.PushAsync("BookList/", book);
        int key = int.Parse(response.Result.name);
        book.Id = key;
        SetResponse setResponse = await _client.SetAsync($"BookList/{book.Id}", book);
    }

    public object AddBookAsync(object id)
    {
        throw new NotImplementedException();
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