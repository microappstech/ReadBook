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
        public Book? Writers { get; set; }
        public IList<BookWriter>? Books { get; set; }
    }
}
