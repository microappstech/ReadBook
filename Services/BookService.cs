using Microsoft.EntityFrameworkCore;
using ReadBookMuds.Data;
using System.Linq;
using ReadBookMuds.Models;
using static MudBlazor.CategoryTypes;
using System.Security.Claims;

namespace ReadBookMuds.Services
{
    public partial class Service 
    {
        public async Task<List<Book>> GetBooks()
        {
            var items = await _context.Books.Include(c=>c.Category).ToListAsync();
            return items;
        }
        public async Task<Book> GetSingleBook(int id)
        {
            var books = _context.Books.AsNoTracking().Where(i => i.Id == id);
            books = books.Include(c => c.Category);
            var book = books.FirstOrDefault();
            return await Task.FromResult(book);
        }
        public async Task<Book> EditBook(Book book)
        {
            var bookToEdit = _context.Books.Where(i=>i.Id == book.Id).FirstOrDefault();
            if (bookToEdit == null)
            {
                throw new Exception("The book no longer availlable");
            }
            try
            {
                bookToEdit.Author = book.Author;
                bookToEdit.Title = book.Title;
                bookToEdit.Description = book.Description;
                bookToEdit.Datepublication = book.Datepublication;
                bookToEdit.DateAdd = book.DateAdd;
                bookToEdit.Icon = book.Icon;
                bookToEdit.Price = book.Price;
                bookToEdit.CategoryId = book.CategoryId;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _context.Entry(bookToEdit).State = EntityState.Unchanged;
                throw;
            }
            return bookToEdit;
        }
        public async Task<Book> CreateBook(Book book)
        {
            var IsExist = _context.Books.Where(i => i.Id == book.Id).FirstOrDefault();
            if (IsExist != null)
            {
                throw new Exception("The book already exist");
            }
            _context.Books.Add(book);
            try
            {
                _context.Entry(book).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(book).State = EntityState.Unchanged;
                throw;
            }
            return book;
        }
        public async Task<Book> DeleteBook(Book book)
        {
            var bookToDelete = _context.Books.Where(i => i.Id == book.Id).FirstOrDefault();
            if (bookToDelete == null)
            {
                throw new Exception("The book not exsit ");
            }
            _context.Books.Remove(book);
            try
            {
                _context.Entry(book).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(book).State = EntityState.Unchanged;
                throw;
            }
            return book;
        }
    }
}
