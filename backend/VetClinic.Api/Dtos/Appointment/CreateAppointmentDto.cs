using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VetClinic.Api.Dtos.Procedure;

namespace VetClinic.Api.Dtos.Appointment
{
    public record CreateAppointmentDto
    {
        [Required] public string Purpose { get; init; } = default!;
        public string? Description { get; init; }
        [Required] public long AnimalId { get; init; }
        [JsonPropertyName("vetId")]
        [Required] public long VeterinarianId { get; init; }
        public IEnumerable<long>? ProcedureIds { get; init; }
    }
}
