using System;
using BookListLibrary.Data;
using BookListLibrary.Services;

namespace BookListTest
{
    public class BookListServiceTests
    {
        [Fact]
        public void GetBookAsync_ReturnsSampleBooks()
        {
            // Arrange
            var service = new BookListService();

            // Act
            var result = service.GetbookAsync().Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
            Assert.Collection(result,
                book => Assert.Equal("To Kill a Mockingbird", book.Title),
                book => Assert.Equal("Pride and Prejudice", book.Title),
                book => Assert.Equal("The Catcher in the Rye", book.Title),
                book => Assert.Equal("1984", book.Title),
                book => Assert.Equal("Harry Potter and the Philosopher's Stone", book.Title)
            );
        }

        [Fact]
        public void GetBookByIdAsync_ReturnsBookWithMatchingId()
        {
            // Arrange
            var service = new BookListService();
            var expectedBook = new BookListLibrary.Data.BookList { Id = 3, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", PublicationDate = new DateTime(1951, 7, 16), Description = "The hero-narrator of The Catcher in the Rye is an ancient child of sixteen, a native New Yorker named Holden Caulfield." };

            // Act
            var result = service.GetBookByIdAsync(3).Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBook.Id, result.Id);
            Assert.Equal(expectedBook.Title, result.Title);
            Assert.Equal(expectedBook.Author, result.Author);
            Assert.Equal(expectedBook.Genre, result.Genre);
            Assert.Equal(expectedBook.PublicationDate, result.PublicationDate);
            Assert.Equal(expectedBook.Description, result.Description);
        }

        [Fact]
        public void GetBookByIdAsync_ReturnsNullForInvalidId()
        {
            // Arrange
            var service = new BookListService();

            // Act
            var result = service.GetBookByIdAsync(100).Result;

            // Assert
            Assert.Null(result);
        }
    }
}