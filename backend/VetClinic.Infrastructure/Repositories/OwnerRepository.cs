using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ClinicDbContext _context;
        public async Task<Owner> GetOwnerByIdAsync(long id)
        {
            return await _context.Owners.SingleOrDefaultAsync(x => x.Id == id) 
                ?? throw new InvalidOperationException($"Could not find owner with given id = {id}");
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
        public async Task AddAsync(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Owner owner)
        {
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }
    }
}