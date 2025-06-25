using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class CommonRepository<T> : IRepository<T> where T : class
    {
        private readonly ClinicDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommonRepository(ClinicDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id)
                ?? throw new InvalidOperationException($"Could not find {nameof(T)} based on provided id = {id}");
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
