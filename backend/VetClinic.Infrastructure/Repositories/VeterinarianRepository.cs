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
                ?? throw new NullReferenceException("Could not find veterinarian based on provided Id");
        }

        // To chyba do usuniecia bo bez sensu raczej tak kombinowac
        public async Task<Veterinarian> GetVeterinarianByAppointmentIdAsync(long appointmentId)
        {
            return await _context.Appointments.SingleOrDefaultAsync(x => x.Id == appointmentId).Result
                ?? throw new NullReferenceException("Could not find veterinarian based on provided appointment Id");
        }

        public async Task<bool> ExistsAsync(string firstName, string lastName)
        {
            //return _context.Veterinarians.SingleOrDefaultAsync()
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
