using Microsoft.EntityFrameworkCore;
using PetFinder.Core.Contracts;
using PetFinder.Core.Models.Dog;
using PetFinder.Infrastructure.Data.Common;
using PetFinder.Infrastructure.Data.Models;

namespace PetFinder.Core.Services
{
    public class DogService : IDogService
    {
        private readonly IRepository repo;

        public DogService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Dog>> GetAllAsync()
            => await repo.AllReadOnly<Dog>().ToListAsync();

        public async Task<Dog?> GetByIdAsync(int id)
        {
            return await repo.GetByIdAsync<Dog>(id);
        }

        public async Task AddAsync(Dog dog)
        {
            await repo.AddAsync(dog);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dog = await repo.GetByIdAsync<Dog>(id);
            if (dog != null)
            {
                await repo.DeleteAsync(dog);
                await repo.SaveChangesAsync();
            }
        }

        Task<IEnumerable<DogViewModel>> IDogService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(DogViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
