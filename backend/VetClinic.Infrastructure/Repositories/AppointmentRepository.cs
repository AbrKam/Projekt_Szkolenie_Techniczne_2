using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class AppointmentRepository : CommonRepository<Appointment>, IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public AppointmentRepository(ClinicDbContext context) : base(context) { _context = context;}

        public async Task<Animal> GetAnimalByAppointmentIdAsync(long id) 
        {
            return await _context.Appointments
                .Where(x => x.Id == id)
                .Select(x => x.Animal)
                .SingleOrDefaultAsync()
                ?? throw new InvalidOperationException($"Could not find animal for appointment with given id = {id}");
        }
        public async Task<Veterinarian> GetVeterinarianByAppointmentIdAsync(long id) 
        {
            return await _context.Appointments
                .Where(x => x.Id == id)
                .Select(x => x.Veterinarian)
                .SingleOrDefaultAsync() 
                ?? throw new InvalidOperationException($"Could not find veterinarian for appointment with given id = {id}");
        }
    }
}
