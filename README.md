🐾 PetFinder
PetFinder is an ASP.NET Core MVC web application that allows searching for pets by microchip number, registering dogs and owners, managing veterinary reports, and performing administrative operations. The system uses user roles, identity management, and access separation through Areas (Admin/User).
---------------------------------------------------
✅ Features
🔍 Search for a dog by chip number

🐶 Add and edit dog profiles

📋 User registration and login

👤 User roles: Admin, Owner

📁 Admin dashboard (Area) - in progress 

🧬 Veterinary reports

📚 Breed management with database connection

📡 Chip search logs with IP address and timestamp

🔒 Protection against XSS, CSRF, and SQL Injection

🔍 Filtering and search functionality - in progress

📄 Custom error pages (404 / 500) - in progress 

✅ Unit testing of business logic (65%+ coverage) - in progress
-------------------------------------------------
🧠 Technologies & Architecture
ASP.NET Core MVC (.NET 6 )

Entity Framework Core

Microsoft SQL Server

ASP.NET Identity for authentication and roles

Razor View Engine (with Layout and Partial Views)

MVC Areas: Admin, User

Built-in Dependency Injection

Repository + Service layers - in progress
----------------------------------------------
PetFinder/
│
├── Infrastructure/
│   ├── Data/Models/         ← Entity models (Dog, Owner, etc.)
│   ├── Repositories/        ← Generic repository
│
├── Core/
│   ├── Contracts/           ← Service interfaces
│   ├── Services/            ← Business logic
│
├── Areas/ - in progress
│   ├── Admin/               ← Admin dashboard and logic
│   └── User/                ← Optional: user area separation
│
├── Controllers/             ← MVC controllers
├── Views/                   ← Razor views
├── wwwroot/                 ← Static files
└── PetFinder.Tests/         ← Unit tests 
----------------------------------------------------------
 🧪Testing - in progress
The project includes xUnit unit tests for:

DogService

OwnerService

Search logic

Validators and business rules

Test coverage reaches 65% or more of the core services.
-------------------------------------------------------
🗃️ Database
Uses Microsoft SQL Server

The database is automatically seeded on first run with:

Roles: Admin, Owner - in progress

Sample users

Breeds, dogs, owners, and veterinary reports


