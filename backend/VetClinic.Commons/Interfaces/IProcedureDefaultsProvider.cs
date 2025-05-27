using VetClinic.Commons.Configuration;

namespace VetClinic.Commons.Interfaces
{
    public interface IProcedureDefaultsProvider
    {
        TimeSpan GetDuration(string code);
        decimal GetPrice(string code);
        ProcedureDefault Get(string code);
    }
}
