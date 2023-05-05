using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using ReadBook.Data;
using ReadBook.Data.IServices;
using ReadBook.Models;

namespace ReadBook.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        private readonly IWriterService writerService;
        private readonly IBookService bookService;
        public WriterController(IWriterService service, IBookService bookService)
        {
            this.writerService = service;
            this.bookService = bookService;
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
            var BookOfWriter =  bookService.GetBooksAsync().Result.Where(b => b.BooksWiters!=null && b.BooksWiters.Any(w => w.WriterId == id)).ToList();

            ViewBag.BookOfWriter = BookOfWriter;
            if (writer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }
        [Authorize("AdminAccess")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [Authorize("AdminAccess")]
        [HttpPost]
        public async Task<IActionResult> Create(Writer writer, IFormFile Picture)
        {
            try
            {
                await writerService.AddAsync(writer, Picture);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

            }
            return RedirectToAction(nameof(Create));
        }
        [Authorize("AdminAccess")]
        public async Task<IActionResult> Edit(int id)
        {
            var writer = await writerService.GetByIdAsync(id);
            if(writer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }
        [Authorize("AdminAccess")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Writer writer, IFormFile Picture)
        {
            try
            {
                await writerService.EditAsync(id, writer, Picture);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }
        [Authorize("AdminAccess")]
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
