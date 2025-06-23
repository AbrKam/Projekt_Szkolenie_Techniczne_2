using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IVeterinarianRepository
    {
        Task<IEnumerable<Veterinarian>> GetAllAsync();
        Task<bool> ExistsAsync(string firstName, string lastName);
    }
}
