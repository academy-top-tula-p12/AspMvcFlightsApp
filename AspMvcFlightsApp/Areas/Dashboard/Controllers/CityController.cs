using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcFlightsApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CityController : Controller
    {
        DataModelDbContext dataContext;
        public CityController(DataModelDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            // 
            return View(dataContext?.Cities?.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DataCity city)
        {
            dataContext?.Cities?.Add(city);
            dataContext?.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id is not null)
            {
                DataCity? city = dataContext?.Cities?.FirstOrDefault(c => c.Id == id);
                if(city is not null)
                    return View(city);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(DataCity city)
        {
            dataContext.Cities?.Update(city);
            dataContext?.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if(id is not null)
            {
                DataCity? city = dataContext?.Cities?.FirstOrDefault(city => city.Id == id);
                if(city is not null)
                {
                    dataContext?.Cities?.Remove(city);
                    dataContext?.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
