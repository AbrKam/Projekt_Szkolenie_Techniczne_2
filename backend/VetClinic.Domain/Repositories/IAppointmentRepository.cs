using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Animal> GetAnimalByAppointmentIdAsync(long id);
        Task<Veterinarian> GetVeterinarianByAppointmentIdAsync(long id);
    }
}
