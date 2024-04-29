using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult Settings()
        {
            return View("Settings");
        }
        [HttpGet]
        public IActionResult SettingGameFirst()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SettingGameFirst(SettingGame settingGame)
        {
            if (ModelState.IsValid)
            {
                DataBase.SettingGame = settingGame;
                for (int i = 0; i < settingGame.Members; i++)
                { settingGame.Participants.Add(new Participant()); }
                return RedirectToAction("SettingGameSecond", "Home");
            }

            return View();
        }
       
        [HttpGet]
        public IActionResult SettingGameSecond()
        {
            SettingGame settingGame=DataBase.SettingGame;
            return View(settingGame);
        }
        [HttpPost]
        public async Task<IActionResult> SettingGameSecond(SettingGame settingGame)
        {
            if(ModelState.IsValid)
            {
                DataBase.SettingGame= settingGame;
                return RedirectToAction("SettingGameThird", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SettingGameThird()
        {
            Judge judge = new Judge();
            return View(judge);
        }
        [HttpPost]
        public async Task<IActionResult> SettingGameThird(Judge judge)
        {
            if (ModelState.IsValid) {
                DataBase.Judge = judge;
                return RedirectToAction("Result", "Home");
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
