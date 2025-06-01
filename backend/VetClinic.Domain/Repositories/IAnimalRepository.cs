using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAnimalRepository
    {
        Task<Animal> GetAnimalByIdAsync(long id);
        Task<IEnumerable<Animal>> GetAllAnimalsAsync();
        Task AddAsync(Animal entity);
        Task UpdateAsync(Animal entity);
        Task RemoveAsync(Animal animal);
    }
}
