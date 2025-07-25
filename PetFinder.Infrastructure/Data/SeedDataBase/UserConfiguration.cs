using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Infrastructure.Data.Models;

namespace PetFinder.Infrastructure.Data.SeedDataBase
{
    internal class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();
            builder.HasData(new ApplicationUser[] {data.AdminUser, data.OwnerUser});
        }
    }
}
