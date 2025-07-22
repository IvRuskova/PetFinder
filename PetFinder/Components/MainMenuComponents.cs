using Microsoft.AspNetCore.Mvc;

namespace PetFinder.Components
{
    public class MainMenuComponents : ViewComponent

    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // You can pass any data to the view if needed
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
