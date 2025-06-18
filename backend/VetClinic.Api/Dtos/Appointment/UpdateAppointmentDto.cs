using VetClinic.Api.Dtos.Procedure;

namespace VetClinic.Api.Dtos.Appointment
{
    public record UpdateAppointmentDto(
        string Purpose,
        string Description,
        long VetId,
        IEnumerable<ProcedureDto> Procedures);
}
