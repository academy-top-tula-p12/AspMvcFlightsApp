using System.Diagnostics;
using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsApp.Controllers
{
    public class HomeController : Controller
    {
        DataModelDbContext dataContext;

        public HomeController(DataModelDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index(AirportSortType sortType = AirportSortType.TitleAsc)
        {
            IQueryable<DataAirport> airports = dataContext.Airports
                                                          .Include(a => a.City);

            ViewBag.titleSort = sortType == AirportSortType.TitleAsc ? AirportSortType.TitleDesc : AirportSortType.TitleAsc;
            ViewBag.citySort = sortType == AirportSortType.CityAsc ? AirportSortType.CityDesc : AirportSortType.CityAsc;

            airports = sortType switch
            {
                AirportSortType.TitleAsc => airports.OrderBy(a => a.Title),
                AirportSortType.TitleDesc => airports.OrderByDescending(a => a.Title),
                AirportSortType.CityAsc => airports.OrderBy(a => a.City.Title),
                AirportSortType.CityDesc => airports.OrderByDescending(a => a.City.Title),
            };

            return View(airports);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
