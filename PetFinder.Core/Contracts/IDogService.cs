using PetFinder.Core.Models.Dog;

namespace PetFinder.Core.Contracts
{
    public interface IDogService
    {
        Task<IEnumerable<DogViewModel>> GetAllAsync();
        Task AddAsync(DogViewModel model);
    }
}
