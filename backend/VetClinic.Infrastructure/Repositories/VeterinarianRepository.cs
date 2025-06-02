using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class VeterinarianRepository : CommonRepository<Veterinarian>, IVeterinarianRepository
    {
        private readonly ClinicDbContext _context;

        public VeterinarianRepository(ClinicDbContext context) : base(context) { _context = context; }

        public async Task<bool> ExistsAsync(string firstName, string lastName)
        {
            return await _context.Veterinarians
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .AnyAsync();
        }
    }
}
