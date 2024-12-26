using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            if(ModelState.IsValid)
            {
                dataContext?.Cities?.Add(city);
                dataContext?.SaveChanges();
                return RedirectToAction("Index");
            }
            //
            string errorMessage = "";
            foreach (var prop in ModelState)
                if (prop.Value.ValidationState == ModelValidationState.Invalid)
                    errorMessage += $"Prop {prop.Key}: {prop.Value.Errors[0].ErrorMessage}\n";
            return Content($"Не задана необходимая информация:\n{errorMessage}");
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

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckTitle(string title)
        {
            if(dataContext.Cities!.Any(c => c.Title == title))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
