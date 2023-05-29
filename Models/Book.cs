using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ReadBookMuds.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public string? Title { get; set; }
        public DateTime Datepublication { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public string Icon { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        [DefaultValue(0)]
        public int Stars { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
