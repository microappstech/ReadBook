using Microsoft.EntityFrameworkCore;
using ReadBook.Data.IServices;
using ReadBook.Models;

namespace ReadBook.Data.Services
{
    public class WriterService : IWriterService
    {
        private readonly DBContext _dbcontext;
        public WriterService(DBContext dBContext)
        {
            this._dbcontext = dBContext;
        }
        public async Task AddAsync(Writer writer)
        {
            await _dbcontext.Writers.AddAsync(writer);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Writer>> GetAllAsync()
        {
            var data = await _dbcontext.Writers.ToListAsync();
            return data;
        }

        public async Task<Writer> GetBYIdAsync(int id)
        {
            var writer = await _dbcontext.Writers.FindAsync(id);
            return writer;
        }

        public async Task RemoveAsync(int id)
        {
            var writer = await _dbcontext.Writers.FindAsync(id);
            _dbcontext.Writers.Remove(writer);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
