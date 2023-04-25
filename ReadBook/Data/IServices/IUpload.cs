namespace ReadBook.Data.IServices
{
    public interface IUpload
    {
        public Task<bool> UploadCover(IFormFile file);
        public Task<bool> UploadPicture(IFormFile picture);
    }
}
