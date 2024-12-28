using Microsoft.AspNetCore.Mvc.Filters;

namespace AspMvcFlightsApp.Filters
{
    public class SimpleResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("last_visit", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
        }
    }
}
