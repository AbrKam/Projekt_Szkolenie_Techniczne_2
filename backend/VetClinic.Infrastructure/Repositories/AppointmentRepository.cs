using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public async Task<Appointment> GetAppointmentByIdAsync(long id) 
        {
            return await _context.Appointments.SingleOrDefaultAsync(x => x.Id == id)
                ?? throw new InvalidOperationException($"Could not find appointment with given id = {id}");
        }
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
        public async Task AddAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
