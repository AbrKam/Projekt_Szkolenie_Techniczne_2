
using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetAppointmentByIdAsync(long id);
        Task<Animal> GetAnimalByAppointmentIdAsync(long id);
        Task<Veterinarian> GetVeterinarianByAppointmentIdAsync(long id);
        Task AddAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
    }
}
