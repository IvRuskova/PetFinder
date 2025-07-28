using Microsoft.EntityFrameworkCore;
using PetFinder.Core.Contracts;
using PetFinder.Infrastructure.Data.Common;
using PetFinder.Infrastructure.Data.Models;

namespace PetFinder.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository repo;

        public OwnerService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await repo.AllReadOnly<Owner>()
                             .Include(o => o.Dogs)
                             .ToListAsync();
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
            return await repo.All<Owner>()
                             .Include(o => o.Dogs)
                             .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Owner owner)
        {
            await repo.AddAsync(owner);
            await repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(Owner owner)
        {
            await repo.UpdateAsync(owner);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var owner = await repo.GetByIdAsync<Owner>(id);
            if (owner != null)
            {
                await repo.DeleteAsync(owner);
                await repo.SaveChangesAsync();
            }
        }
    }

}
