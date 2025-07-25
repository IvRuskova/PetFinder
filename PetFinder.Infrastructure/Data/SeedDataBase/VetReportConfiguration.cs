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
    internal class VetReportConfiguration : IEntityTypeConfiguration<VetReport>
    {
        public void Configure(EntityTypeBuilder<VetReport> builder)
        {
            var data = new SeedData();

            builder.HasData(data.Report1, data.Report2);
        }
    }
}