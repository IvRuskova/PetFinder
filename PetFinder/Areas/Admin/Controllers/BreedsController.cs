using Microsoft.AspNetCore.Mvc;
using PetFinder.Data;

namespace PetFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BreedsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BreedsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Breeds.ToList());
        }
    }
}
