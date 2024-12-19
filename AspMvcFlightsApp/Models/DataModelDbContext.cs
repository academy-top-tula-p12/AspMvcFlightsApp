using AspMvcFlightsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsApp.Models
{
    public class DataModelDbContext : DbContext
    {
        public DbSet<DataCity>? Cities { get; set; }
        public DbSet<DataAirport>? Airports { get; set; }
        public DbSet<DataAirline>? Airlines { get; set; }
        public DbSet<DataFlight>? Flights { get; set; }


        public DataModelDbContext(DbContextOptions<DataModelDbContext> options)
            : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer(connectionString);

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
