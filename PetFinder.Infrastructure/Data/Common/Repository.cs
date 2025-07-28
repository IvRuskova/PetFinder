using Microsoft.EntityFrameworkCore;
using PetFinder.Infrastructure.Data.Models;

namespace PetFinder.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(PetFinderDbContext context)
        {
            _context = context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public Task DeleteAsync<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}