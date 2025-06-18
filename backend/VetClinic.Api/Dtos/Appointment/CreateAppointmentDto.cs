using VetClinic.Api.Dtos.Procedure;

namespace VetClinic.Api.Dtos.Appointment
{
    public record CreateAppointmentDto(
        string Purpose,
        string Description,
        long VetId,
        long AnimalId,
        IEnumerable<ProcedureDto> Procedures);
}
