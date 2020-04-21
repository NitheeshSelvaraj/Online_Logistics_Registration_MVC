using Online_Logistics_Registration_Entity;
using System.Data.Entity;

namespace Online_Logistics_Registration_Repository
{
    public class UserContext:DbContext
    {
        public UserContext():base("Connection")
        {

        }
        public DbSet<User> UserDetails { get; set; }
        public DbSet<Vehicle> VehicleDetails { get; set; }
        public DbSet<VehicleType> VehicleTypeDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>().MapToStoredProcedures();
            modelBuilder.Entity<Vehicle>().MapToStoredProcedures();
        }
    }
}
