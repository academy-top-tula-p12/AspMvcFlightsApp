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
    }
}
