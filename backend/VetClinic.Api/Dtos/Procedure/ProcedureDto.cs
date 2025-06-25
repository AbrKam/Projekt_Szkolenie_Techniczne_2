namespace VetClinic.Api.Dtos.Procedure
{
    public class ProcedureDto
    {
        public long Id { get; set; }
        public string ProcedureCode { get; set; }
        public decimal Price { get; set; }
        public TimeSpan EstimatedTime { get; set; }
    }
}
