using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using VetClinic.Api.Dtos.Owner;
using VetClinic.Domain.Entities;
using VetClinic.Infrastructure.Repositories;

namespace VetClinic.Api.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(OwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> Get(long id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null) return NotFound();
            var result = _mapper.Map<OwnerDto>(owner);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetAll() 
        {
            var owners = await _ownerRepository.GetAllAsync();
            if (owners == null) return Ok(Enumerable.Empty<OwnerDto>());
            var result = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOwnerDto createOwnerDto)
        {
            var owner = _mapper.Map<Owner>(createOwnerDto);
            if (owner == null) return NotFound();
            await _ownerRepository.AddAsync(owner);
            var result = _mapper.Map<OwnerDto>(owner);

            return CreatedAtAction(nameof(Get), new {id = result.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateOwnerDto updateOwnerDto)
        {
            var existing = await _ownerRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(updateOwnerDto, existing);
            await _ownerRepository.UpdateAsync(existing);
            var result = _mapper.Map<OwnerDto>(existing);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null) return NotFound();
            await _ownerRepository.DeleteAsync(owner);

            return NoContent();
        }
        
    }
}
