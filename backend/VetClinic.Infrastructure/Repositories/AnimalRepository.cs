using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class AnimalRepository : CommonRepository<Animal>, IAnimalRepository
    {
        private readonly ClinicDbContext _context;

        public AnimalRepository(ClinicDbContext context) : base(context) {_context = context;}

        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
            return await _context.Animals.ToListAsync();
        }
    }
}
