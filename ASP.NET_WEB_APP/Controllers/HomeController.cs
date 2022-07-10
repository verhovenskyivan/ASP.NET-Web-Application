using ASP.NET_WEB_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_WEB_APP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult PrintValue()
        {
            int age = 20;
            string name = "Ivan Verhovensky";
            var user = new User { Name = name, Age = age };
            return View(User);
        }

        [HttpGet]
        public IActionResult PrintValuesCollection()
        {
            var numbersList = new List<int> { 1, 2, 3, 4, 5 };
            var numbersArray = new string[] { "1", "2", "3" };
            var users = new List<User>
            {
                new User {Name = "Иван Верховенский", Age = 20}
            };
            return View(numbersList);
        }
        private readonly IConfiguration Configuration;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult PrintInfo()
        {
            return View();
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

        [HttpGet]
        public IActionResult CreateUser() => View();

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _userService.AddUser(model.Name);
                return RedirectToAction("GetAllUsers", "Accouts");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class CreateUserViewModel
    {
        [Required(ErrorMessage = " Введите Имя")]
        [MaxLength(50,ErrorMessage= " Длина не должна превышать 50 символов")]
        public string Name { get; set; }

        [Range(1,110, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
    }
}