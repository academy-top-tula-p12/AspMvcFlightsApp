namespace AspMvcFlightsApp.Models
{
    public class DataFlight
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DataAirline? Airline { get; set; }
        public DataAirport? Departure { get; set; }
        public DataAirport? Arrival { get; set; }
        public DateTime DateTime { get; set; }
    }
}
