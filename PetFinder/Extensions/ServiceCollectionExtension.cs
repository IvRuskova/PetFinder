using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure.Data;

namespace PetFinder.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPetFinderServices(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddPetFinderDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<PetFinderDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
        public static IServiceCollection AddPetFinderIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
           {
               options.SignIn.RequireConfirmedAccount = false;
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireNonAlphanumeric = false;
           })
                .AddEntityFrameworkStores<PetFinderDbContext>();
            return services;
        }
    }
}
