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
        [Required]
        public Category? Category { get; set; }
        public IList<BookWriter>? writers { get; set; }
    }
}
