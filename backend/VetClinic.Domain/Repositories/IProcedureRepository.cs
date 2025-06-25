using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Domain.Entities;

namespace VetClinic.Domain.Repositories
{
    public interface IProcedureRepository : IRepository<Procedure>
    {
        Task<IEnumerable<Procedure>> GetAllAsync();
    }
}
