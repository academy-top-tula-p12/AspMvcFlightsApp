using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsApp.Models
{
    public class DataCity
    {
        public int Id { get; set; }

        [Display(Name = "Название Города")]
        [Required(ErrorMessage = "Название города обязательно")]
        [Remote(action: "CheckTitle", 
                controller: "City", 
                areaName: "Dashboard", 
                ErrorMessage = "Такой город уже есть")]
        [DataType(DataType.Text)]
        public string Title { get; set; } = null!;
    }
}
