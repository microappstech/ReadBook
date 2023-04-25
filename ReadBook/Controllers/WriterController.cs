using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadBook.Data;
using ReadBook.Data.IServices;
using ReadBook.Models;

namespace ReadBook.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService writerService;
        private readonly IBookService bookService;
        private readonly DBContext dBContext;
        public WriterController(IWriterService service, IBookService bookService, DBContext dBContext)
        {
            this.writerService = service;
            this.bookService = bookService;
            this.dBContext = dBContext;
        }
        public async Task<IActionResult> Index()
        {
            var data = await writerService.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            IEnumerable<BookWriter> bookwriter = writerService.Bookwriter(id).Result;

            var writer = await writerService.GetByIdAsync(id);
            //var books = await bookService.GetBooksAsync();
            var BookOfWriter =  bookService.GetBooksAsync().Result.Where(b => b.BooksWiters!=null && b.BooksWiters.Any(w => w.WriterId == id)).ToList();

            ViewBag.BookOfWriter = BookOfWriter;
            if (writer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Writer writer, IFormFile picture)
        {
            try
            {
                await writerService.AddAsync(writer, picture);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

            }
            return RedirectToAction(nameof(Create));
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
