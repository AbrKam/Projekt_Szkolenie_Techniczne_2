using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
    }
}
