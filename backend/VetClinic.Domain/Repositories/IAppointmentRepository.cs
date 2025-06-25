using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Animal> GetAnimalByAppointmentIdAsync(long id);
        Task<Veterinarian> GetVeterinarianByAppointmentIdAsync(long id);
    }
}
