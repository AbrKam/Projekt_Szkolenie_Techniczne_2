using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IVeterinarianRepository
    {
        Task<Veterinarian> GetVeterinarianByIdAsync(long id);
        Task<Veterinarian> GetVeterinarianByAppointmentIdAsync(long animalId);
        Task<bool> ExistsAsync(string firstName, string lastName);
        Task AddAsync(Veterinarian vet);
        Task DeleteAsync(Veterinarian vet);
        Task UpdateAsync(Veterinarian vet);
    }
}
