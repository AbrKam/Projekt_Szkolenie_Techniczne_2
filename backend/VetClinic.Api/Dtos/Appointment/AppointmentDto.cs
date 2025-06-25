using VetClinic.Api.Dtos.Procedure;

namespace VetClinic.Api.Dtos.Appointment
{
    public record AppointmentDto
    {
        public long Id { get; init; }
        public string Purpose { get; init; } = default!;
        public string? Description { get; init; }
        public long AnimalId { get; init; }
        public long VeterinarianId { get; init; }
        public DateTime CreatedOn { get; init; }
        public IEnumerable<long> ProcedureIds { get; init; } = Array.Empty<long>();
    }
}
