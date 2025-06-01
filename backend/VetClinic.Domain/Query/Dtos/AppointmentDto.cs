using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Query.Dtos
{
    public sealed record AppointmentDto(string Purpose, string Description, Veterinarian Veterinarian, Animal Animal, ICollection<Procedure> Procedures);
}
