using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetAllAsync();
    }
}
