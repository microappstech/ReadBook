using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReadBook.Models;
using System.Diagnostics;

namespace ReadBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(SignInManager<AppUser> signInManager, ILogger<HomeController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
               

        public async Task<IActionResult> Logout()
        {
            string returnUrl = "/?page=%2F";
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return LocalRedirect(returnUrl);
        }

    }
}