using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class VeterinarianRepository : IVeterinarianRepository
    {
        private readonly ClinicDbContext _context;

        public async Task<Veterinarian> GetVeterinarianByIdAsync(long id)
        {
            return await _context.Veterinarians.SingleOrDefaultAsync(x => x.Id == id) 
                ?? throw new InvalidOperationException($"Could not find veterinarian based on provided id = {id}");
        }

        public async Task<bool> ExistsAsync(string firstName, string lastName)
        {
            return await _context.Veterinarians
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .AnyAsync();
        }
        public async Task AddAsync(Veterinarian vet)
        {
            _context.Veterinarians.Add(vet);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Veterinarian vet)
        {
            _context.Veterinarians.Remove(vet);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Veterinarian vet)
        {
            _context.Veterinarians.Update(vet);
            await _context.SaveChangesAsync();
        }
    }
}
