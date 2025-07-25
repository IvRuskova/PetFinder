using Microsoft.AspNetCore.Mvc;
using PetFinder.Core.Models.Dog;

namespace PetFinder.Controllers
{
    public class DogController : Controller
    {
        public async Task<IActionResult> All()
        {
            var model = new DogViewModel();
            return View(model);
        }
    }
}
