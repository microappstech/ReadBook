using ReadBook.Models;

namespace ReadBook.Data.IServices
{
    public interface IWriterService
    {
        public Task<IEnumerable<Writer>> GetAllAsync();
        public Task<Writer> GetBYIdAsync(int id);
        public Task AddAsync(Writer writer);
        public Task RemoveAsync(int id);
    }
}
