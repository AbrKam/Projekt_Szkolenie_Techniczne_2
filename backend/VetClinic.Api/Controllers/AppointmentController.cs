using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Api.Dtos.Appointment;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Repositories;

namespace VetClinic.Api.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IVeterinarianRepository _veterinarianRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMapper _mapper;

        public AppointmentController(
            IAppointmentRepository appointmentRepository,
            IAnimalRepository animalRepository,
            IVeterinarianRepository veterinarianRepository,
            IProcedureRepository procedureRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _animalRepository = animalRepository;
            _veterinarianRepository = veterinarianRepository;
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            var appointmentEntities = await _appointmentRepository.GetAllAsync();
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointmentEntities);
            return Ok(appointmentDtos);
        }

        [HttpGet("{id}", Name = "GetAppointmentById")]
        public async Task<ActionResult<AppointmentDto>> GetById(long id)
        {
            var appointmentEntity = await _appointmentRepository.GetByIdAsync(id);
            if (appointmentEntity == null)
                return NotFound();

            var appointmentDto = _mapper.Map<AppointmentDto>(appointmentEntity);
            return Ok(appointmentDto);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Create([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var animalEntity = await _animalRepository.GetByIdAsync(createAppointmentDto.AnimalId);
            var veterinarianEntity = await _veterinarianRepository.GetByIdAsync(createAppointmentDto.VeterinarianId);

            var appointmentEntity = new Appointment(
                createAppointmentDto.Purpose,
                createAppointmentDto.Description,
                veterinarianEntity,
                animalEntity);

            if (createAppointmentDto.ProcedureIds != null)
            {
                foreach (var procedureId in createAppointmentDto.ProcedureIds)
                {
                    var procedureEntity = await _procedureRepository.GetByIdAsync(procedureId);
                    appointmentEntity.AddProcedure(procedureEntity);
                }
            }

            await _appointmentRepository.AddAsync(appointmentEntity);

            var appointmentDto = _mapper.Map<AppointmentDto>(appointmentEntity);
            return CreatedAtRoute(
                routeName: "GetAppointmentById",
                routeValues: new { id = appointmentDto.Id },
                value: appointmentDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentDto>> Update(long id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
            if (existingAppointment == null)
                return NotFound();

            existingAppointment.SetPurpose(updateAppointmentDto.Purpose);
            existingAppointment.SetDescription(updateAppointmentDto.Description);

            if (existingAppointment.AnimalId != updateAppointmentDto.AnimalId)
            {
                var newAnimal = await _animalRepository.GetByIdAsync(updateAppointmentDto.AnimalId);
                existingAppointment.SetAnimal(newAnimal);
            }
            if (existingAppointment.VeterinarianId != updateAppointmentDto.VeterinarianId)
            {
                var newVet = await _veterinarianRepository.GetByIdAsync(updateAppointmentDto.VeterinarianId);
                existingAppointment.SetVeterinarian(newVet);
            }

            existingAppointment.GetAllProcedures().ToList()
                .ForEach(p => existingAppointment.Procedures.Remove(p));
            if (updateAppointmentDto.ProcedureIds != null)
            {
                foreach (var procedureId in updateAppointmentDto.ProcedureIds)
                {
                    var procedureEntity = await _procedureRepository.GetByIdAsync(procedureId);
                    existingAppointment.AddProcedure(procedureEntity);
                }
            }

            await _appointmentRepository.UpdateAsync(existingAppointment);

            var appointmentDto = _mapper.Map<AppointmentDto>(existingAppointment);
            return Ok(appointmentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var appointmentEntity = await _appointmentRepository.GetByIdAsync(id);
            if (appointmentEntity == null)
                return NotFound();

            await _appointmentRepository.DeleteAsync(appointmentEntity);
            return NoContent();
        }
    }
}
