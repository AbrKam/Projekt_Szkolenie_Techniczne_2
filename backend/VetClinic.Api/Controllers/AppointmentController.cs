using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Api.Dtos.Appointment;
using VetClinic.Domain.Entities;
using VetClinic.Infrastructure.Repositories;

namespace VetClinic.Api.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentController(AppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> Get(long id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            var result = _mapper.Map<AppointmentDto>(appointment);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(createAppointmentDto);
            if(appointment == null) return NotFound();
            await _appointmentRepository.AddAsync(appointment);
            var result = _mapper.Map<AppointmentDto>(appointment);

            return CreatedAtAction(nameof(Get), new {id = result.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentDto>> Update(long id, UpdateAppointmentDto updateAppointmentDto)
        {
            var existing = await _appointmentRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();
           
            _mapper.Map(updateAppointmentDto, existing);
            await _appointmentRepository.UpdateAsync(existing);
            var result = _mapper.Map<AppointmentDto>(existing);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            
            await _appointmentRepository.DeleteAsync(appointment);
            
            return NoContent();
        }

    }
}
