using Microsoft.AspNetCore.Mvc;
using motiv.Models;
using System.Diagnostics;

namespace motiv.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult AbonentList() 
        //{
        //    return RedirectToAction("Index", "Abonent");
        //    //return View();
        //}


    }
}