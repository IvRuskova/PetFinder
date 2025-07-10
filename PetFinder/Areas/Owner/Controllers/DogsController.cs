using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;

namespace PetFinder.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DogsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() 
        { 
            var dogs = _context.Dogs.Include(d=>d.Breed).ToList();
            return View(dogs);
        }
    }
}
