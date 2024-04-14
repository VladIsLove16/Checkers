using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Xml.Linq;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Index(string username)
        {
            var context = ControllerContext.HttpContext;
            context.Session.Set<Person>("Person",new Person() { Name= username });
            context.Response.Cookies.Append("name", username);
            return View("Index");
        }

        public IActionResult Entrance()
        {
            return View("Entrance");
        }

        public IActionResult Reg_arbitr()
        {
            return View("Reg_arbitr");
        }

        public IActionResult Reg_player()
        {
            return View("Reg_player");
        }

        public IActionResult MainStr()
        {
            return View("MainStr");
        }

        public IActionResult ChoiceSystem()
        {
            var context= ControllerContext.HttpContext;
            var model = new ViewModelTest();
                model.Person.Name = context.Request.Cookies["name"]??"Имя пусто";
            return View(model);
        }

        public IActionResult History()
        {
            return View("History");
        }

        public IActionResult Profile()
        {
            return View("Profile");
        }

        public IActionResult Result()
        {
            return View("Result");
        }

        public IActionResult SettingGamePlayer()
        {
            return View("SettingGamePlayer");
        }

        public IActionResult Settings()
        {
            return View("Settings");
        }

        public IActionResult SettingsGameArbiter()
        {
            return View("SettingsGameArbiter");
        }

        public IActionResult SettingsGameArbiterPlayers()
        {
            return View("SettingsGameArbiterPlayers");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
