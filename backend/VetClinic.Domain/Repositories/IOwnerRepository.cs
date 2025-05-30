using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner> GetOwnerByIdAsync(long id);
        Task<Owner> GetOwnerByAnimalIdAsync(long animalId);
        Task<bool> ExistsAsync(string firstName, string lastName);
        Task AddAsync(Owner owner);
        Task DeleteAsync(Owner owner);
        Task UpdateAsync(Owner owner);
    }
}
