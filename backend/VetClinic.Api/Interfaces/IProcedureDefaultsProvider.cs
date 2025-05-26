namespace VetClinic.Api.Interfaces
{
    public interface IProcedureDefaultsProvider
    {
        TimeSpan GetDuration(string code);
        double GetPrice(string code);
        ProcedureDefault Get(string code);
    }
}
