using BookListLibrary.Services;

namespace BookListTest
{
    public class BookListServiceTests
    {
        private object book;

        [Fact]
        public void GetBookAsync_ReturnsSampleBooks()
        {
            // Arrange
            var service = new BookListService();

            // Act
            var result = service.GetAllBooksAsync().Result;

            // Assert
            Assert.NotNull(result);
            // Update the number of books you expect in your test data
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void AddBookAsync_BookIsAddedSuccessfully()
        {
            // Arrange
            var service = new BookListService();
            var newBook = new BookListLibrary.Data.BookList { Title = "New Book", Author = "Author Name", Genre = "Fiction", Description = "A new book for testing" };

            // Act
            service.AddBookAsync(newBook).Wait();
            var addedBook = service.AddBookAsync(book.Id).Result;

            // Assert
            Assert.NotNull(addedBook);
            Assert.Equal(newBook.Title, addedBook.Title);
            Assert.Equal(newBook.Author, addedBook.Author);
            Assert.Equal(newBook.Genre, addedBook.Genre);
            Assert.Equal(newBook.Description, addedBook.Description);
        }



        [Fact]
        public void DeleteBookAsync_BookIsDeletedSuccessfully()
        {
            // Arrange
            var service = new BookListService();
            var bookToDelete = new BookListLibrary.Data.BookList { Title = "Book To Delete", Author = "Author Name", Genre = "Fiction", Description = "A book to be deleted for testing" };
            service.AddBookAsync(bookToDelete).Wait();

            // Act
            //  service.DeleteBookAsync(bookToDelete.Id).Wait();
            var deletedBook = service.GetBookByIdAsync(bookToDelete.Id).Result;

            // Assert
            Assert.Null(deletedBook);
        }
    }
}
