using Microsoft.AspNetCore.Mvc;
using ReadBook.Data.IServices;

namespace ReadBook.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService writerService;
        public WriterController(IWriterService service)
        {
            this.writerService = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await writerService.GetAllAsync();
            return View(data);
        }

    }
}
