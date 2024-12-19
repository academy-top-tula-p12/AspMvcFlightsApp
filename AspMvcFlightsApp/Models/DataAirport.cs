namespace AspMvcFlightsApp.Models
{
    public class DataAirport
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        
        public int? CityId { get; set; }
        public DataCity? City { get; set; }
    }
}
