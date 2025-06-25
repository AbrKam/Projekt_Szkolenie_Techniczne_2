using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IVeterinarianRepository : IRepository<Veterinarian>
    {
        Task<IEnumerable<Veterinarian>> GetAllAsync();
        Task<bool> ExistsAsync(string firstName, string lastName);
    }
}
