
using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetAppointmentByIdAsync(long id);
        Task<Appointment> GetAppointmentByAnimalIdAsync(long animalId);
        Task<Appointment> GetAppointmentByVeterinarianIdAsync(long veterinarianId);
        Task AddAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
    }
}
