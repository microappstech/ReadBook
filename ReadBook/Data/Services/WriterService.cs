using Microsoft.EntityFrameworkCore;
using ReadBook.Data.IServices;
using ReadBook.Models;

namespace ReadBook.Data.Services
{
    public class WriterService : IWriterService
    {
        private readonly DBContext _dbcontext;
        readonly IUpload upload;

        public WriterService(DBContext dBContext, IUpload uploadFile)
        {
            this._dbcontext = dBContext;
            this.upload = uploadFile;
        }

        public async Task<IEnumerable<Writer>> GetAllAsync()
        {
            var data = await _dbcontext.Writers.ToListAsync();
            return data;
        }
        public async Task<Writer> GetByIdAsync(int id)
        {
            var writer = await _dbcontext.Writers.FindAsync(id);
            return writer;
        }
        public async Task AddAsync(Writer writer,IFormFile formFile)
        {
            var uploader = await upload.UploadPicture(formFile);
            if (uploader)
            {
                await _dbcontext.Writers.AddAsync(writer);

            }
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookWriter>> Bookwriter(int? idwriter, int? idbook)
        {
            if(idwriter == null && idbook == null)
            {
                throw new Exception("Error in your informations");
            }
            var data = await _dbcontext.Writers_Books.Where(bw=>bw.WriterId == idwriter || bw.BookId == idbook).ToListAsync();
            return data;
        }

        public async Task EditAsync(int id, Writer writer, IFormFile formFile)
        {
            //var EditedWriter = await _dbcontext.Writers.FindAsync(id);
            //var uplodedPicture = await upload.UploadPicture(formFile);
            //if (uplodedPicture)
            //{
            //    EditedWriter.Picture = formFile.FileName;
            //    EditedWriter.Name = writer.Name;
            //    EditedWriter.Nationality = writer.Nationality;
            //}
            await _dbcontext.SaveChangesAsync();

        }

        public async Task RemoveAsync(int id)
        {
            var writer = await _dbcontext.Writers.FindAsync(id);
            _dbcontext.Writers.Remove(writer);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
