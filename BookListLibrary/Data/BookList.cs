using System;
using System.ComponentModel.DataAnnotations;

namespace BookListLibrary.Data
{
    public class BookList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Author name must be at least 3 characters long.")]
        public string Author { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Genre must contain only letters and spaces.")]
        public string Genre { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
