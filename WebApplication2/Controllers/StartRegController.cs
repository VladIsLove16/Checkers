using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
   
        public class StartRegController : Controller
        {
            public IActionResult Index()
            {
                return View("~/Views/Home/start_reg/Index.cshtml");
            }
        public IActionResult Entrance()
        {
            return View("~/Views/Home/start_reg/entrance.cshtml");
        }

        public IActionResult Reg_arbitr()
        {
            return View("~/Views/Home/start_reg/Reg_arbitr.cshtml");
        }

        public IActionResult Reg_player()
        {
            return View("~/Views/Home/start_reg/Reg_player.cshtml");
        }
    }
   
}
