using Microsoft.Extensions.Options;
using VetClinic.Api.Interfaces;

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


    }
}
