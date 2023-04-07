using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Library.Data
{
    public class BookListService
    {
        private static readonly List<BookList> SampleBooks = new List<BookList>
        {
            new BookList { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic", PublicationDate = new DateTime(1960, 7, 11), Description = "A gripping, heart-wrenching, and wholly remarkable tale of coming-of-age in a South poisoned by virulent prejudice."},
            new BookList { Id = 2, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", PublicationDate = new DateTime(1813, 1, 28), Description = "Austen's timeless romantic classic, follows the lives of the five Bennett sisters, who live in a time where an advantageous marriage and social status are considered a fundamental for any woman to stand a fair chance at life."},
            new BookList { Id = 3, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", PublicationDate = new DateTime(1951, 7, 16), Description = "The hero-narrator of The Catcher in the Rye is an ancient child of sixteen, a native New Yorker named Holden Caulfield."},
            new BookList { Id = 4, Title = "1984", Author = "George Orwell", Genre = "Dystopian", PublicationDate = new DateTime(1949, 6, 8), Description = "Orwell's chilling prophecy about the future brings to life a world where absolute conformity in action, word and thought is enforced."},
            new BookList { Id = 5, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Genre = "Fantasy", PublicationDate = new DateTime(1997, 6, 26), Description = "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. It's an extraordinary moment for Harry when he discovers at the age of eleven that he is a wizard, and he is soon enrolled at Hogwarts School of Witchcraft and Wizardry."}
        };

        public Task<List<BookList>> GetbookAsync()
        {
            return Task.FromResult(SampleBooks);
        }

        public Task<BookList> GetBookByIdAsync(int id)
        {
            return Task.FromResult(SampleBooks.FirstOrDefault(book => book.Id == id));
        }
    }
}


