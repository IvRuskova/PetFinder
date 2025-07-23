using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure.Data.Models;

namespace PetFinder.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
