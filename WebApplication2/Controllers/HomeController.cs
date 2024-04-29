using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        public IActionResult Index()
        {
            return View("Index");
        }



        public IActionResult ProfileSecond()
        {
            return View("ProfileSecond");
        }

        public IActionResult ChoiceSystem()
        {
            
            return View();
        }

        public IActionResult Profile()
        {
            return View("Profile");
        }

        public IActionResult Result()
        {
            return View("Result");
        }
        public IActionResult ResultPlaces()
        {
            return View("ResultPlaces");
        }
        public IActionResult SettingGameFirst()
        {
            var SettingGame=new SettingGame();
            return View(SettingGame);
        }

        public IActionResult Settings()
        {
            return View("Settings");
        }
        public IActionResult SettingGameSecond()
        {
            return View("SettingGameSecond");
        }

        public IActionResult SettingGameThird()
        {
            return View("SettingGameThird");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
