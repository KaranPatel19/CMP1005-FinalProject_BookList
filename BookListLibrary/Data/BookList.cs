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
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        public string PublicationDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
