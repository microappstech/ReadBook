using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadBook.Data;
using ReadBook.Data.IServices;
using ReadBook.Data.Services;
using ReadBook.Models;

namespace ReadBook.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;            
        }
        // GET: BookController
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetBooksAsync();
            return View(books);
        }

        // GET: BookController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await bookService.GetBookAsync(id);
            if(book == null)
            {
                return View();
            }
            return View(book);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            var Categories = bookService.GetCategories();
            ViewBag.Categories = new SelectList(Categories, "Id", "Name");
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, IFormFile cover)
        {
            try
            {
                await bookService.AddBookAsync(book, cover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(book);
            }
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await bookService.GetBookAsync(id);
            if(book==null) return RedirectToAction(nameof(Index));
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book collection, IFormFile cover)
        {
            try
            {
                var book = await bookService.GetBookAsync(id);
                if (book == null) return RedirectToAction(nameof(Edit));
                await bookService.EditAsync(id,collection,cover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await bookService.GetBookAsync(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var book = await bookService.GetBookAsync(id);
                if (book == null) return View("NotFound");
                bookService.DeleteBookAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    
    }
}
