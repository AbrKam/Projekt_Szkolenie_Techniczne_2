using VetClinic.Api.Dtos.Procedure;

namespace VetClinic.Api.Dtos.Appointment
{
    public sealed record AppointmentDto(
        long Id, 
        string Purpose, 
        string Description, 
        long VetId, 
        long AnimalId,
        IEnumerable<ProcedureDto> Procedures);
}
