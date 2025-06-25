using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Api.Dtos.Animal;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;

namespace VetClinic.Api.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalRepository animalRepository, IMapper mapper) 
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDto>> Get(long id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null) return NotFound();
            var result = _mapper.Map<AnimalDto>(animal);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAll()
        {
            var animals = await _animalRepository.GetAllAsync();
            if (animals == null) return Ok(Enumerable.Empty<AnimalDto>());
            var result = _mapper.Map<IEnumerable<AnimalDto>>(animals);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAnimalDto createAnimalDto)
        {
            var animal = _mapper.Map<Animal>(createAnimalDto);
            if (animal == null) return NotFound();

            await _animalRepository.AddAsync(animal);
            var result = _mapper.Map<AnimalDto>(animal);

            return CreatedAtAction(nameof(Get), new {id =  result.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateAnimalDto updateAnimalDto)
        {
            var existing = await _animalRepository.GetByIdAsync(id);
            if(existing == null) return NotFound();

            _mapper.Map(updateAnimalDto, existing);
            await _animalRepository.UpdateAsync(existing);
            var result = _mapper.Map<AnimalDto>(existing);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if(animal == null) return NotFound();
            await _animalRepository.DeleteAsync(animal);

            return NoContent();
        }

    }
}
