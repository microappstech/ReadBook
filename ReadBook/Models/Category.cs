using System.ComponentModel.DataAnnotations;

namespace ReadBook.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
