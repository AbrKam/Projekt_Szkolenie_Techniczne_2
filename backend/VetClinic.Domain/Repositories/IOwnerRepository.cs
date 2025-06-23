using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner> GetOwnerByAnimalIdAsync(long animalId);
        Task<bool> ExistsAsync(string firstName, string lastName);
    }
}
