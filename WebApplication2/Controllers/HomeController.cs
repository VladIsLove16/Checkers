using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
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
            return View("ChoiceSystem");
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