using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
        public static IServiceCollection AddPetFinderIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
