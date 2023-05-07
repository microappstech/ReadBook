using ReadBook.Data.IServices;

namespace ReadBook.Data.Services
{
    public class UploadFile : IUpload
    {
        public async Task UploadPicture(IFormFile picture)
        {
            string path = "";

            if (picture !=null && picture.Length>0)
            {
                string picturename = picture.FileName;
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\Users"));
                if(!Directory.Exists(path)) 
                {
                    Directory.CreateDirectory(path);
                }
                using (var stream = new FileStream(Path.Combine(path, picturename), FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
            }
        }
        public async Task<bool> UploadCover(IFormFile file)
        {
            string path = string.Empty;
            if(file.Length > 0)
            {
                string filename = file.FileName;
                //C:\Users\Hamza\Desktop\ReadBook\ReadBook\wwwroot\images\Book\
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\Book"));
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using(var filestream = new FileStream(Path.Combine(path,filename),FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
                return true;

            }
            return false;
        }
    }
}
