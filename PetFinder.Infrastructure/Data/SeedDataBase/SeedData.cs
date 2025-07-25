using Microsoft.AspNetCore.Identity;
using PetFinder.Infrastructure.Data.Models;

namespace PetFinder.Infrastructure.Data.SeedDataBase
{
    internal class SeedData
    {
            public ApplicationUser AdminUser { get; set; }
            public ApplicationUser OwnerUser { get; set; }

            public Owner Owner1 { get; set; }
            public Owner Owner2 { get; set; }
            public Owner Owner3 { get; set; }

            public Breed GermanShepherd { get; set; }
            public Breed Poodle { get; set; }
            public Breed AkitaInu { get; set; }

            public Dog Dog1 { get; set; }
            public Dog Dog2 { get; set; }
            public Dog Dog3 { get; set; }

            public VetReport Report1 { get; set; }
            public VetReport Report2 { get; set; }

            public ChipSearchLog Log1 { get; set; }
            public ChipSearchLog Log2 { get; set; }

            public SeedData()
            {
                SeedUsers();
                SeedOwners();
                SeedBreeds();
                SeedDogs();
                SeedVetReports();
                SeedLogs();
            }

            private void SeedUsers()
            {
                var hasher = new PasswordHasher<ApplicationUser>();

                AdminUser = new ApplicationUser
                {
                    Id = "admin-001",
                    UserName = "admin@petfinder.com",
                    NormalizedUserName = "ADMIN@PETFINDER.COM",
                    Email = "admin@petfinder.com",
                    NormalizedEmail = "ADMIN@PETFINDER.COM"
                };
                AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin123!");

                OwnerUser = new ApplicationUser
                {
                    Id = "owner-001",
                    UserName = "owner@petfinder.com",
                    NormalizedUserName = "OWNER@PETFINDER.COM",
                    Email = "owner@petfinder.com",
                    NormalizedEmail = "OWNER@PETFINDER.COM"
                };
                OwnerUser.PasswordHash = hasher.HashPassword(OwnerUser, "Owner123!");
            }

            private void SeedOwners()
            {
                Owner1 = new Owner
                {
                    Id = 1,
                    FullName = "Ivan Ivanov",
                    PhoneNumber = "0888123456",
                    Email = "ivan@example.com",
                    Address = "ul. Bylgaria 125, Sofia",

                };

                Owner2 = new Owner
                {
                    Id = 2,
                    FullName = "Maria Georgiewa",
                    PhoneNumber = "0899111222",
                    Email = "maria@abv.bg",
                    Address = "Lulin 10, Sofia"
                };

                Owner3 = new Owner
                {
                    Id = 3,
                    FullName = "Petya Dobrewa",
                    PhoneNumber = "0899114562",
                    Email = "petya@abv.bg",
                    Address = "zona B-15, Sofia"
                };
        }

            private void SeedBreeds()
            {
                GermanShepherd = new Breed { Id = 1, Name = "German Shepherd" };
                Poodle = new Breed { Id = 2, Name = "Poodle" };
                AkitaInu = new Breed { Id = 3, Name = "Akita Inu" };
            }

            private void SeedDogs()
            {
                Dog1 = new Dog
                {
                    Id = 1,
                    Name = "Rex",
                    ChipNumber = "BG123456",
                    Age = 3,
                    BreedId = GermanShepherd.Id,
                    OwnerId = Owner1.Id
                };

                Dog2 = new Dog
                {
                    Id = 2,
                    Name = "Bony",
                    ChipNumber = "BG654321",
                    Age = 5,
                    BreedId = Poodle.Id,
                    OwnerId = Owner2.Id
                    
                };
                Dog3 = new Dog
                {
                    Id = 3,
                    Name = "Mia",
                    ChipNumber = "BG654788",
                    Age = 5,
                    BreedId = Poodle.Id,
                    OwnerId = Owner2.Id
                };
            }

            private void SeedVetReports()
            {
                Report1 = new VetReport
                {
                    Id = 1,
                    DogId = Dog1.Id,
                    Date = new DateTime(2024, 6, 1),
                    Description = "Vaccination and check."
                };

                Report2 = new VetReport
                {
                    Id = 2,
                    DogId = Dog2.Id,
                    Date = new DateTime(2024, 6, 15),
                    Description = "Treatment."
                };
            }

            private void SeedLogs()
            {
                Log1 = new ChipSearchLog
                {
                    Id = 1,
                    ChipNumber = "BG123456",
                    SearchDate = DateTime.UtcNow.AddDays(-1),
                    IpAddress = "192.168.1.100"
                };

                Log2 = new ChipSearchLog
                {
                    Id = 2,
                    ChipNumber = "BG654321",
                    SearchDate = DateTime.UtcNow,
                    IpAddress = "192.168.1.101"
                };
            }
    }
}

