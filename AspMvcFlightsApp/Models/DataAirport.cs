using AspMvcFlightsApp.Areas.Dashboard.Types;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsApp.Models
{
    public class DataAirport
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название аэропорта обязательно")]
        public string Title { get; set; } = null!;

        //[CityRequired(ErrorMessage = "Не выбран город")]
        [Remote(areaName: "Dashboard", 
                controller: "Airport", 
                action: "CheckCity",
                ErrorMessage = "Город не выбран")]
        public int? CityId { get; set; }

        //[CityRequired(ErrorMessage = "Не выбран город")]
        public DataCity? City { get; set; }



        //[RegularExpression(@"", ErrorMessage = "")]
        //[StringLength(20, MinimumLength = 8, ErrorMessage = "")]
        //[Range(16, 80, ErrorMessage = "")]

        //[CreditCard]
        //[EmailAddress]
        //[Phone]
        //[Url]
        //string Prop {  get; set; }

        //[Required]
        //[StringLength(20, MinimumLength = 8, ErrorMessage = "")]
        //public string Password { get; set; } = null!;

        //[Required]
        //[Compare(nameof(Password), ErrorMessage = "")]
        //public string PasswordConfirm { get; set; } = null!;

        
        //public string Password { get; set; } = null!;


    }
}
