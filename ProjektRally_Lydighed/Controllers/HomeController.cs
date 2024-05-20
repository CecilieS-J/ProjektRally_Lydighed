using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektRally_Lydighed.Models;
using System.Diagnostics;

namespace ProjektRally_Lydighed.Controllers
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

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult UserProfil()
        {
            return View();
        }

        // Denne metode er kun tilg�ngelig for administratorer
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminOnly()
        {
            return View();
        }



    }
}
