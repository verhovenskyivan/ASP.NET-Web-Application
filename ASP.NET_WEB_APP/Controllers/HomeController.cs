using ASP.NET_WEB_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_WEB_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult PrintInfo()
        {
            return View();
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var adminName = Configuration.GetSection("Admin:Name");
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
}