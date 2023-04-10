using System.ComponentModel.DataAnnotations;

namespace ReadBook.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Nationality { get; set; }
        public string? Picture { get; set; } = "defaultPicture.png";
        public IList<BookWriter>? BooksWiters { get; set; }
    }
}
