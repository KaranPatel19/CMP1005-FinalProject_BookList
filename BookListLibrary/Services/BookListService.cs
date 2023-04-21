using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database;
using Newtonsoft.Json;
using FireSharp.EventStreaming;

using Newtonsoft.Json.Linq;
using BookListLibrary.Exceptions;
using BookListLibrary.Data;
using System.ComponentModel.DataAnnotations;
using System.IO;

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
       // PushResponse response = await _client.PushAsync("BookList/", book);
        //int key = int.Parse(response.Result.name);
        //book.Id = key;

        SetResponse setResponse = await _client.SetAsync($"BookList/{book.Id}", book);
    }
    public async Task SaveBookAsync(int Id, string Title, string Author, string Genre, string Description)
    {
        var book = new BookList { Id = Id, Title = Title, Author = Author, Genre = Genre, Description = Description };
        await _client.SetAsync($"BookList/{Id}", book);
    }

    public async Task DeleteBookAsync(int Id)
    {
       await _client.DeleteAsync($"BookList/{Id}");

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