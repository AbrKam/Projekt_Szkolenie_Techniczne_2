using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Api.Dtos.Procedure;
using VetClinic.Domain.Repositories;

namespace VetClinic.Api.Controllers
{

        [ApiController]
        [Route("api/procedures")]
        public class ProcedureController : ControllerBase
        {
            private readonly IProcedureRepository _repo;
            private readonly IMapper _mapper;
            public ProcedureController(IProcedureRepository repo, IMapper mapper)
            {
                _repo = repo; _mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ProcedureDto>>> GetAll()
            {
                var items = await _repo.GetAllAsync();
                var dtos = _mapper.Map<IEnumerable<ProcedureDto>>(items);
                return Ok(dtos);
            }
        }
}
