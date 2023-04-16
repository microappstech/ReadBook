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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
