using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TallerAPI.Data.Entities;

namespace TallerAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Procedure> procedure { get; set; }
        public DbSet<VehicleType> vehicleTypes { get; set; }
        public DbSet<DocumentType> documentType { get; set; }
        public DbSet<Brand> brand { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Detail> details { get; set; }
        public DbSet<History> histories { get; set; }
        public DbSet<VehiclePhoto> vehiclePhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plaque).IsUnique();
        }
    }
}
