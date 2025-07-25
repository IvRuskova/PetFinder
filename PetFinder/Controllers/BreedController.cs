using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure.Data;

namespace PetFinder.Controllers
{
    public class BreedController : Controller
    {
        private readonly PetFinderDbContext _context;

        public BreedController(PetFinderDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var breeds = await _context.Breeds
                .OrderBy(b => b.Name)
                .ToListAsync();

            return View(breeds);
        }
    }
}

