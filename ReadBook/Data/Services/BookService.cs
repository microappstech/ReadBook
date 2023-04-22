using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadBook.Data.IServices;
using ReadBook.Models;
using System.Xml.Serialization;

namespace ReadBook.Data.Services
{
    public class BookService : IBookService
    {
        private readonly DBContext _context;
        readonly IUpload upload;
        public BookService(DBContext dBContext, IUpload upload)
        {
            this._context = dBContext;
            this.upload = upload;
        }
        public async Task AddBookAsync(Book book, IFormFile formFile)
        {
            Book bookT = new Book
            {
                Name = book.Name,
                CategoryId = book.CategoryId,
                DateCreation = book.DateCreation,
                Resume = book.Resume,
                Cover = formFile.FileName
            };
            await _context.Books.AddAsync(bookT);
            var uploadedfile = await upload.UploadCover(formFile);
            if (uploadedfile)
            {
                await _context.SaveChangesAsync();

            } 
            
        }
        public async Task DeleteBookAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(int id, Book book , IFormFile formFile)
        {
            Book bookTo  = await _context.Books.FindAsync(id);
            bookTo.Name = book.Name;
            bookTo.Price=book.Price;
            bookTo.CategoryId = book.CategoryId;
            bookTo.Cover = formFile.FileName;
            bookTo.DateCreation = book.DateCreation;

            var uploadedfile = await upload.UploadCover(formFile);
            _context.SaveChanges();

        }
        public async Task<Book> GetBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }
        public async Task<List<Book>> GetBooksAsync()
        {
           var books = await _context.Books.ToListAsync();
            return books;
        }
        public IEnumerable<Category> GetCategories()
        {
            var data = _context.Categories.ToList().OrderBy(c=>c.Name);
            return data;
        }
    }
}
