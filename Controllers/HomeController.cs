using Microsoft.AspNetCore.Mvc;
using ScireHub.Models;
using System.Diagnostics;

namespace ScireHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Miperfil()
        {
            return View();
        }
        public IActionResult Registrate()
        {
            return View();
        }

        public IActionResult Investigadores()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}