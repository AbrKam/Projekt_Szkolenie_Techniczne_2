using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public async Task<Appointment> GetAppointmentByIdAsync(long id) {}
        public async Task<Appointment> GetAppointmentByAnimalIdAsync(long animalId) { }
        public async Task<Appointment> GetAppointmentByVeterinarianIdAsync(long veterinarianId){}
        public async Task AddAsync(Appointment appointment){}
        public async Task DeleteAsync(Appointment appointment){}
        public async Task UpdateAsync(Appointment appointment){}
    }
}
