using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;

namespace PetFinder.Areas.Public.Controllers
{
    [Area("Public")]
    public class ChipSearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChipSearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string chipNumber)
        {
            if (string.IsNullOrWhiteSpace(chipNumber))
            {
                return View("Index");
            }
            var dog = _context.Dogs
                .Include(d => d.Breed)
                .Include(d => d.Owner)
                .FirstOrDefault(d => d.ChipNumber == chipNumber);
            if (dog == null)
            {
                return View("NotFound");
            }
            return View("Result", dog);
        }
    }
}
