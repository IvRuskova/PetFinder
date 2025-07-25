using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Infrastructure.Data.SeedDataBase
{
    internal class ChipSearchLogConfiguration : IEntityTypeConfiguration<ChipSearchLog>
    {
        public void Configure(EntityTypeBuilder<ChipSearchLog> builder)
        {
            var data = new SeedData();

            builder.HasData(data.Log1, data.Log2);
        }
    }
}
