using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetFinder.Models;
using PetFinder.Models.Enums;

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

            //Unique index in Db
            builder.Entity<Dog>()
                .HasIndex(d => d.ChipNumber)
                .IsUnique();


            //Seed Breeds
            builder.Entity<Breed>().HasData(
                   new Breed { Id = 1, Name = "Germen Shepards"},
                   new Breed { Id = 2, Name = "Poodles" },
                   new Breed { Id = 3, Name = "Saint Bernard" }
                );

            //Seed owners
            builder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 1,
                    FullName = "Ivan Ivanov",
                    PhoneNumber = "0888123456",
                    Email = "ivan@example.com",
                    Address = "ul. Bylgaria 125, Sofia"
                },
                new Owner
                {
                    Id = 2,
                    FullName = "Maria Georgiewa",
                    PhoneNumber = "0899111222",
                    Email = "maria@abv.bg",
                    Address = "Lulin 10, Sofia"
                }
            );

            //Seed dogs
            builder.Entity<Dog>().HasData(
                new Dog
                {
                    Id = 1,
                    Name = "Rex",
                    ChipNumber = "BG123456",
                    Age = 3,
                    BreedId = 1,  //Germen Sheperds
                    OwnerId = 1,
                    Status = DogStatus.Healthy
                },
                new Dog
                {
                    Id = 2,
                    Name = "Bony",
                    ChipNumber = "BG654321",
                    Age = 5,
                    BreedId = 2,  //Poodles
                    OwnerId = 2,
                    Status = DogStatus.Lost
                }
            );
            builder.Entity<VetReport>()
                   .HasOne(v => v.Dog)
                   .WithMany(d => d.VetReports)
                   .HasForeignKey(v => v.DogId);


            // 🩺 Seed for vet report
            builder.Entity<VetReport>().HasData(
                new VetReport
                {
                    Id = 1,
                    DogId = 1,
                    Date = new DateTime(2024, 6, 1),
                    Description = "Vaccination and check."
                },
                new VetReport
                {
                    Id = 2,
                    DogId = 2,
                    Date = new DateTime(2024, 6, 15),
                    Description = "Treatment."
                }
            );

            // 🔍 Seed search logs
            builder.Entity<ChipSearchLog>().HasData(
                new ChipSearchLog
                {
                    Id = 1,
                    ChipNumber = "BG123456",
                    SearchDate = DateTime.UtcNow.AddDays(-1),
                    IpAddress = "192.168.1.100"
                },
                new ChipSearchLog
                {
                    Id = 2,
                    ChipNumber = "BG654321",
                    SearchDate = DateTime.UtcNow,
                    IpAddress = "192.168.1.101"
                }
            );

        }

    }
}
