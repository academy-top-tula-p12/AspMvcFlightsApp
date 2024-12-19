using System.Diagnostics;
using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcFlightsApp.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
