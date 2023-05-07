using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBook.Models
{
    public class Writer
    {
        [Key] public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string Email { get; set; } = string.Empty;

        [NotMapped][Required] public string userid { get; set; }
        public string? Bio { get; set; }
        [Required] public string? Nationality { get; set; }
        public string? Picture { get; set; } = "defaultPicture.png";
        public IList<BookWriter>? BooksWiters { get; set; }
    }
}
