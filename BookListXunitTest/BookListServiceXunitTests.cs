using Xunit;
using Moq;
using FluentAssertions;
using BookListLibrary.Data;
using BookListLibrary.Services;
using FireSharp.Interfaces;

public class BookListServiceXunitTests
{
    [Fact]
    public async Task AddBookAsync_ShouldAddBookSuccessfully()
    {
        // Arrange
        var mockClient = new Mock<IFirebaseClient>();
        var service = new BookListService(mockClient.Object);
        var newBook = new BookList
        {
            Title = "Test Book",
            Author = "Test Author",
            Genre = "Test Genre",
            Description = "Test Description"
        };

        // Act
        await service.AddBookAsync(newBook);

        // Assert
        mockClient.Verify(client => client.PushAsync("BookList/", newBook), Times.Once);
    }

    
}
