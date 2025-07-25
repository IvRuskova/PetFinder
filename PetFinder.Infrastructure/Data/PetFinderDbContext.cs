using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure.Data.Models;
using PetFinder.Infrastructure.Data.SeedDataBase;

namespace PetFinder.Infrastructure.Data
{
    public class PetFinderDbContext : IdentityDbContext
    {
        public PetFinderDbContext(DbContextOptions<PetFinderDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Breed> Breeds { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OwnerConfiguration());
            builder.ApplyConfiguration(new BreedConfiguration());
            builder.ApplyConfiguration(new DogConfiguration());
            builder.ApplyConfiguration(new VetReportConfiguration());
            builder.ApplyConfiguration(new ChipSearchLogConfiguration());

        }
    }
}
