namespace VetClinic.Api.Dtos.Procedure
{
    public sealed record ProcedureDto(
        string ProcedureCode, 
        decimal Price, 
        TimeSpan EstimatedDuration, 
        long VetId, 
        long AnimalId);
}
