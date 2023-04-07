using Xunit;
using System.Collections.Generic;
using System.Linq;
using BookList.Library.Data;

namespace BookList.Tests
{
    public class BookListServiceTests
    {
        [Fact]
        public async void GetbookAsync_ReturnsAllBooks()
        {
            // Arrange
            var service = new BookListService();

            // Act
            var books = await service.GetbookAsync();

            // Assert
            Assert.Equal(5, books.Count);
        }

        [Theory]
        [InlineData(1, "To Kill a Mockingbird")]
        [InlineData(2, "Pride and Prejudice")]
        [InlineData(3, "The Catcher in the Rye")]
        public async void GetBookByIdAsync_ReturnsCorrectBook(int id, string expectedTitle)
        {
            // Arrange
            var service = new BookListService();

            // Act
            var book = await service.GetBookByIdAsync(id);

            // Assert
            Assert.Equal(expectedTitle, book.Title);
        }
    }
}
