using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadBook.Data.IServices;
using ReadBook.Models;

namespace ReadBook.Data.Services
{
    public class BookService : IBookService
    {
        private readonly DBContext _context;
        public BookService(DBContext dBContext)
        {
            this._context = dBContext;
        }
        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, Book book)
        {
            Book bookTo  = await _context.Books.FindAsync(id);
            bookTo.Name = book.Name;
            bookTo.Price=book.Price;
            bookTo.CategoryId = book.CategoryId;
            bookTo.Cover = book.Cover;
            bookTo.DateCreation = book.DateCreation;
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
    }
}
