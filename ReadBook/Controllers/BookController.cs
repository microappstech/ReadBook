using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadBook.Data;
using ReadBook.Data.IServices;
using ReadBook.Data.Services;
using ReadBook.Models;

namespace ReadBook.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;            
        }


        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetBooksAsync();
            return View(books);
        }



        public async Task<IActionResult> Details(int id)
        {
            var book = await bookService.GetBookAsync(id);
            if(book == null)
            {
                return View();
            }
            return View(book);
        }
        
        [Authorize("AdminAccess")]
        public IActionResult Create()
        {
            var Categories = bookService.GetCategories();
            ViewBag.Categories = new SelectList(Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("AdminAccess")]
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


        [Authorize("AdminAccess")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await bookService.GetBookAsync(id);
            if(book==null) return RedirectToAction(nameof(Index));
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("AdminAccess")]
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


        [Authorize("AdminAccess")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await bookService.GetBookAsync(id);
            return View(book);
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("AdminAccess")]
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
