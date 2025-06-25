using System.ComponentModel.DataAnnotations;

namespace VetClinic.Api.Dtos.Appointment
{
    public record UpdateAppointmentDto
    {
        [Required] public string Purpose { get; init; } = default!;
        public string? Description { get; init; }
        [Required] public long AnimalId { get; init; }
        [Required] public long VeterinarianId { get; init; }
        public List<long>? ProcedureIds { get; init; }
    }
}
