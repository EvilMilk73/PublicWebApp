using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class DataContext : DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }
        public DbSet<MapRoute> Routes { get; set; }
    }
}
