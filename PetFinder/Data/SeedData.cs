using Microsoft.EntityFrameworkCore;
using PetFinder.Models;

namespace PetFinder.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            await context.SaveChangesAsync();

            if (!context.Breeds.Any())
            {
                context.Breeds.AddRange(
                     new Breed { Name = "Germen Shepards" },
                     new Breed { Name = "Poodles" },
                     new Breed { Name = "Saint Bernard" }
                    );

            }
        }
    }
}
