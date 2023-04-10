namespace ReadBook.Models
{
    public class BookWriter
    {
        public int BookId { get; set; }
        public Book? book { get; set; }
        public int WriterId { get; set; }
        public Writer? writer { get; set; }
    }
}
