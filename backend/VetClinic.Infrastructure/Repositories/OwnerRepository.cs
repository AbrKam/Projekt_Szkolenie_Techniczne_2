using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class OwnerRepository : CommonRepository<Owner>, IOwnerRepository
    {
        private readonly ClinicDbContext _context;

        public OwnerRepository(ClinicDbContext context) : base(context) { _context = context; }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync()
                ?? throw new InvalidOperationException("Could not get owners list");
        }

        public async Task<Owner> GetWithAnimalsByIdAsync(long id)
        {
            var owner = await _context.Owners
                .Include(o => o.Animals)
                .SingleOrDefaultAsync(o => o.Id == id);

            if (owner == null)
                throw new InvalidOperationException($"Owner {id} not found.");

            return owner;
        }

        public async Task<Owner> GetOwnerByAnimalIdAsync(long animalId)
        {
            return await _context.Animals
                .Where(x => x.Id == animalId)
                .Select(x => x.Owner)
                .SingleOrDefaultAsync() 
                ?? throw new InvalidOperationException($"Could not find owner for animal with given id = {animalId}");
        }
        public async Task<bool> ExistsAsync(string firstName, string lastName)
        {
            return await _context.Owners
            .Where(x => x.FirstName == firstName && x.LastName == lastName)
            .AnyAsync();
        }
    }
}