using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueries
{
    class BookLinq
    {
        static void Main(string[] args)
        {
            // Create a list of books
            List<Book> books = new List<Book>()
            {
                new Book() { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", PublicationYear = 1960 },
                new Book() { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Fiction", PublicationYear = 1813 },
                new Book() { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", PublicationYear = 1951 },
                new Book() { Title = "1984", Author = "George Orwell", Genre = "Fiction", PublicationYear = 1949 },
                new Book() { Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Genre = "Fantasy", PublicationYear = 1997 }
            };

            // Filter books by genre
            List<Book> fictionBooks = books.Where(b => b.Genre == "Fiction").ToList();

            // Sort books by publication year
            List<Book> sortedBooks = books.OrderBy(b => b.PublicationYear).ToList();

            // Group books by author
            var booksByAuthor = books.GroupBy(b => b.Author);

            // Count books by genre
            var bookCountByGenre = books.GroupBy(b => b.Genre).Select(g => new { Genre = g.Key, Count = g.Count() });

            // Print results
            Console.WriteLine("Fiction books:");
            foreach (var book in fictionBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}");
            }

            Console.WriteLine("Sorted books:");
            foreach (var book in sortedBooks)
            {
                Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
            }

            Console.WriteLine("Books by author:");
            foreach (var group in booksByAuthor)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var book in group)
                {
                    Console.WriteLine($"- {book.Title}");
                }
            }

            Console.WriteLine("Book count by genre:");
            foreach (var count in bookCountByGenre)
            {
                Console.WriteLine($"{count.Genre}: {count.Count}");
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
    }
}
