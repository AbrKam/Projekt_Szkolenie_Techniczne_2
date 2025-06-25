using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner> GetWithAnimalsByIdAsync(long id);
        Task<Owner> GetOwnerByAnimalIdAsync(long animalId);
        Task<bool> ExistsAsync(string firstName, string lastName);
    }
}
