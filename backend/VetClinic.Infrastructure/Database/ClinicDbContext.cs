using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;

namespace VetClinic.Infrastructure.Database
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) {}

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;Database=clinic;Trusted_Connection=True;TrustServerCertificate=True;",
        //        x => x.MigrationsHistoryTable("__EFMigrationHistory", "Clinic"));
        //}
    }
}
