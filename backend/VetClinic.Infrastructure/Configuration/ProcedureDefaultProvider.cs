using Microsoft.Extensions.Options;
using VetClinic.Commons.Interfaces;
using VetClinic.Commons.POCO.Configuration;

namespace VetClinic.Infrastructure.Configuration
{
    public class ProcedureDefaultProvider : IProcedureDefaultsProvider
    {
        private readonly Dictionary<string, ProcedureDefault> _map;
        private static readonly TimeSpan _defaultDuration = TimeSpan.FromMinutes(20);
        private const decimal _defaultPrice = 100m;

        public ProcedureDefaultProvider(IOptions<ProcedureDefaultSettings> options)
        {
            _map = options.Value.Items
                .ToDictionary(x => x.Code, StringComparer.OrdinalIgnoreCase);
        }

        public TimeSpan GetDuration(string code)
            => _map.TryGetValue(code, out ProcedureDefault procedureDefault) 
            ? procedureDefault.Duration 
            : _defaultDuration;

        public decimal GetPrice(string code)
            => _map.TryGetValue(code, out ProcedureDefault procedureDefault) 
            ? procedureDefault.Price
            : _defaultPrice;

        public ProcedureDefault Get(string code)
            => _map.TryGetValue(code, out ProcedureDefault procedureDefault)
            ? procedureDefault
            : new ProcedureDefault(code, 
                _defaultDuration, 
                _defaultPrice);
    }
}
