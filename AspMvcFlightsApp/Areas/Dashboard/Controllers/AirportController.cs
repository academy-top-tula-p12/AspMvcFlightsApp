using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AirportController : Controller
    {
        DataModelDbContext dataContext;

        public AirportController(DataModelDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View(dataContext.Airports
                                   .Include(a => a.City));
        }

        public IActionResult Create()
        {
            ViewBag.cities = dataContext?.Cities?.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(DataAirport? airport)
        {
            if(airport is not null)
            {
                dataContext.Airports.Add(airport);
                dataContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id is not null)
            {
                DataAirport? airport = dataContext.Airports.FirstOrDefault(a => a.Id == id);
                if (airport is not null)
                {
                    ViewBag.cities = dataContext?.Cities?.ToList();
                    return View(airport);
                }
            }
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(DataAirport airport)
        {
            dataContext?.Airports?.Update(airport);
            dataContext?.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id is not null)
            {
                DataAirport? airport = dataContext.Airports.FirstOrDefault(a => a.Id == id);
                if (airport is not null)
                {
                    dataContext.Airports.Remove(airport);
                    dataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
