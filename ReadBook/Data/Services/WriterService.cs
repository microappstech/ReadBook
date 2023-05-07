using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReadBook.Areas.Identity.Data;
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
            //this._userManager = userManager;
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
            var user = Activator.CreateInstance<AppUser>();
            user.Email = (writer.Name + "@gmal.com").Replace(" ", "");
            user.UserName = writer.Name.Replace(" ","");
            writer.userid = user.Id;
            //var resultCreated = await _userManager.CreateAsync(user, writer.Name.Replace(" ","") + '!');
            writer.Picture = formFile!=null ? formFile.FileName : writer.Picture;
            
            if (formFile != null)
                writer.Picture = formFile.FileName;
                await upload.UploadPicture(formFile);
            //if (resultCreated.Succeeded)
            //{
            //    await _dbcontext.Writers.AddAsync(writer);
            //    await _dbcontext.SaveChangesAsync();
            //}
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
            try
            {

                var EditedWriter = await _dbcontext.Writers.FindAsync(id);
                await upload.UploadPicture(formFile);
                EditedWriter.Name = writer.Name;
                EditedWriter.Nationality = writer.Nationality;
                EditedWriter.Picture = formFile.FileName;
                await _dbcontext.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception("");
            }

        }

        public async Task RemoveAsync(int id)
        {
            var writer = await _dbcontext.Writers.FindAsync(id);
            _dbcontext.Writers.Remove(writer);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
