using ReadBook.Models;

namespace ReadBook.Data.IServices
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task AddBookAsync(Book book,IFormFile formFile);
        Task DeleteBookAsync(int id);
        Task EditAsync(int id, Book book, IFormFile formFile);
        IEnumerable<Category> GetCategories();
    }
}
