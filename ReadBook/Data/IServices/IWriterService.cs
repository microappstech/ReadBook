using ReadBook.Models;

namespace ReadBook.Data.IServices
{
    public interface IWriterService
    {
        public Task<IEnumerable<Writer>> GetAllAsync();
        public Task<Writer> GetByIdAsync(int id);
        public Task AddAsync(Writer writer, IFormFile formFile);
        public Task RemoveAsync(int id);
        public Task EditAsync(int id, Writer writer, IFormFile formFile);
        public Task<IEnumerable<BookWriter>> Bookwriter(int? idwriter= null, int? idbook=null);
    }
}
