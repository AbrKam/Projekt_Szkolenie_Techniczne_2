using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;

namespace VetClinic.Infrastructure.Repositories
{
    public class ProcedureRepository : CommonRepository<Procedure>, IProcedureRepository
    {
        private readonly ClinicDbContext _context;
        public ProcedureRepository(ClinicDbContext context) : base(context) { _context = context; }

        public async Task<IEnumerable<Procedure>> GetAllAsync()
        {
            return await _context.Procedures.ToListAsync()
                ?? throw new InvalidOperationException("Could not get appointment list");
        }
    }
}
