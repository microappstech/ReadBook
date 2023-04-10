using Azure;
using System.ComponentModel.DataAnnotations;

namespace ReadBook.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public  double Price { get; set; }
        [Display(Name = "Date of creation")]
        public DateTime DateCreation { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public String Cover { get; set; } = "defaulCover.png";
        public Category? Category { get; set; }
        public IList<BookWriter>? BooksWiters { get; set; }
    }
}
