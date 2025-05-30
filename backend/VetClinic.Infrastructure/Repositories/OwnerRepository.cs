using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ClinicDbContext _context;
        public async Task<Owner> GetOwnerByIdAsync(long id){}
        public async Task<Owner> GetOwnerByAnimalIdAsync(long animalId){}
        public async Task<bool> ExistsAsync(string firstName, string lastName){}
        public async Task AddAsync(Owner owner){}
        public async Task DeleteAsync(Owner owner){}
        public async Task UpdateAsync(Owner owner){}
    }
}