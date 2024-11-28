using Microsoft.EntityFrameworkCore;
using CarRentalMS.Models; // Make sure this is added

namespace CarRentalMS.Data
{
    public class CarRentalMSContext : DbContext
    {
        public CarRentalMSContext(DbContextOptions<CarRentalMSContext> options) : base(options) { }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Rent> Rent { get; set; }
    }
}
