using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Core.Models.Search;

namespace PetFinder.Controllers
{
    public class SearchController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new SearchViewModel();
            return View(model);
        }
    }
}
