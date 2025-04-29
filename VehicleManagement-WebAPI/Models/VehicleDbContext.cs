using Microsoft.EntityFrameworkCore;

namespace VehicleManagement_WebAPI.Models
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) :base(options) { }

        public DbSet<VehicleModel> Vehicles { get; set; }

        //To connect to the database, configure the context class, use optionsbuilder to specify the connection string.
        //add the connection string to appSettings & program.cs files

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog= VehicleDB; Integrated Security= True;Trust Server Certificate=False;");
            }
        }
    }
}
