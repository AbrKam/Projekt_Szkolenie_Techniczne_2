using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Api.Dtos.Veterinarian;
using VetClinic.Domain.Entities;
using VetClinic.Infrastructure.Repositories;

namespace VetClinic.Api.Controllers
{
    [ApiController]
    [Route("api/veterinarians")]
    public class VeterinarianController : ControllerBase
    {
        private readonly VeterinarianRepository _repository;
        private readonly IMapper _mapper;

        public VeterinarianController(VeterinarianRepository repo, IMapper mapper) 
        {
            _repository = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeterinarianDto>> Get(long id) 
        {
            var vet = await _repository.GetByIdAsync(id);
            if (vet == null) return NotFound();
            var result = _mapper.Map<VeterinarianDto>(vet);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VeterinarianDto>> Create(CreateVeterinarianDto veterinarianDto)
        {
            var entity = _mapper.Map<Veterinarian>(veterinarianDto);
            await _repository.AddAsync(entity);
            var result = _mapper.Map<VeterinarianDto>(entity);

            return CreatedAtAction(nameof(Get), new { id = result.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateVeterinarianDto veterinarianDto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(veterinarianDto, existing);
            await _repository.UpdateAsync(existing);
            var result = _mapper.Map<VeterinarianDto>(existing);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var vet = await _repository.GetByIdAsync(id);
            if (vet == null) return NotFound();

            await _repository.DeleteAsync(vet);
            
            return NoContent();
        }
    }
}
