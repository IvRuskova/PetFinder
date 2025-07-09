using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetFinder.Models;

namespace PetFinder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dog>? Dogs { get; set; }
        public DbSet<Breed>? Breeds { get; set; }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<VetReport> VetReports { get; set; }
        public DbSet<ChipSearchLog> ChipSearchLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Breed>().HasData(
                   new Breed { Id = 1, Name = "Germen Shepards"},
                   new Breed { Id = 2, Name = "Poodles" },
                   new Breed { Id = 3, Name = "Saint Bernard" }
                );
        }

    }
}
