using AspMvcFlightsApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsApp.Areas.Dashboard.Types
{
    public class CityRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DataAirport airport = (DataAirport)validationContext.ObjectInstance;
            
            if(airport.CityId > 0)
                return ValidationResult.Success;
            else
                return new ValidationResult("Город не выбран");
        }
    }
}
