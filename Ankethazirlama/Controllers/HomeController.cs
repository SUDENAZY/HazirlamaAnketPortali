using System.Diagnostics;
using Ankethazirlama.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ankethazirlama.Controllers
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class HomeController : Controller, IHomeController
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public IActionResult GiriþYap()
        {
            return View();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
