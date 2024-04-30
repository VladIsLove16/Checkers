using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Models.SortSystems;
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

       
        public IActionResult Profile()
        {
            return View("Profile");
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
        public IActionResult ChoiceSystem()
        {
            SettingGame settingGame = DataBase.SettingGame;
            return View(settingGame);
        }
        [HttpPost]
        public IActionResult ChoiceSystem(SettingGame settingGame)
        {
            DataBase.SettingGame = settingGame;
            return View();
        }
        [HttpGet]
        public IActionResult SettingGameFirst(string choice,string sortSystem)
        {
            SettingGame settingGame = DataBase.SettingGame;

            Console.WriteLine("Выбрана система сортировки: "+ sortSystem);
            switch (sortSystem)
            {
                case "Круговая":
                    {
                        settingGame.SortSystem = new RoundSortSystem();
                        break;
                    }
                case "Олимпийская":
                    {
                        settingGame.SortSystem = new OlympicSortSystem();
                        break;
                    }
                case "Cхевенингенская":
                    {
                        settingGame.SortSystem = new ScheveningenSortSystem();
                        break;
                    }
                case "Швейцарская":
                    {
                        settingGame.SortSystem = new SwissSortSystem();
                        break;
                    }
                default:
                    break;
            }
            Console.WriteLine("Задействована система сортировки: " + settingGame.SortSystem);
            return View(settingGame);
        }
        [HttpPost]
        public async Task<IActionResult> SettingGameFirst(SettingGame settingGame)
        {

            Console.Write("Проверка. система сортировки: " + DataBase.SettingGame.SortSystem);
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
            SettingGame settingGame = DataBase.SettingGame;
            return View(settingGame);
        }
        [HttpPost]
        public async Task<IActionResult> SettingGameThird(SettingGame settingGame)
        {
            if (ModelState.IsValid) {
                DataBase.SettingGame = settingGame;
                Console.WriteLine(DataBase.SettingGame.Members);
                return RedirectToAction("Result", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Result()
        {
            
            SettingGame settingGame = DataBase.SettingGame;
            StartTournament(settingGame);
            return View(settingGame);
        }

        private static void StartTournament(SettingGame settingGame)
        {
            Tournament tournament = TournamentCreator.Create();

            tournament.SortSystem = settingGame.SortSystem;

            tournament.PrizeCount = settingGame.PrizeCount;

            foreach (var participant in settingGame.Participants)
                tournament.AddParticipant(participant);

            tournament.Judge = settingGame.Judge;

            DataBase.AddTournament(tournament);
            tournament.Start();
        }

        [HttpPost]
        public IActionResult Result(SettingGame settingGame)
        {
            if (ModelState.IsValid)
            {
                DataBase.SettingGame = settingGame;
                return RedirectToAction("Result", "Home");
            }
            return View("Result");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
