using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using BookList.Web;
using System.Text.Json;
using BookList.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

namespace BookList.IntegrationTests
{
    public class BooksControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public BooksControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsAllBooks()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/books");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonString = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<BookList>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.Equal(5, books.Count);
        }
    }
}
