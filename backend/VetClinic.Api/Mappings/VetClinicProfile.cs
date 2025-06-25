using AutoMapper;
using VetClinic.Domain.Entities;
using VetClinic.Api.Dtos.Animal;
using VetClinic.Api.Dtos.Appointment;
using VetClinic.Api.Dtos.Owner;
using VetClinic.Api.Dtos.Veterinarian;
using VetClinic.Api.Dtos.Procedure;

namespace VetClinic.Api.Mappings
{
    public class VetClinicProfile : Profile
    {
        public VetClinicProfile() 
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<CreateAnimalDto, Animal>();
            CreateMap<UpdateAnimalDto, Animal>();
            CreateMap<IEnumerable<AnimalDto>, IEnumerable<Animal>>();    

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<IEnumerable<AppointmentDto>, IEnumerable<Appointment>>();
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(d => d.AnimalId, o => o.MapFrom(s => s.AnimalId))
                .ForMember(d => d.VeterinarianId, o => o.MapFrom(s => s.VeterinarianId))
                .ForMember(d => d.CreatedOn, o => o.MapFrom(s => s.CreatedOn))
                .ForMember(d => d.ProcedureIds, o => o.MapFrom(s => s.Procedures.Select(p => p.Id)));

            CreateMap<Owner, OwnerDto>();
            CreateMap<CreateOwnerDto, Owner>();
            CreateMap<UpdateOwnerDto, Owner>();
            CreateMap<IEnumerable<OwnerDto>, IEnumerable<Owner>>();

            CreateMap<Veterinarian, VeterinarianDto>();
            CreateMap<CreateVeterinarianDto, Veterinarian>();
            CreateMap<UpdateVeterinarianDto, Veterinarian>();
            CreateMap<IEnumerable<VeterinarianDto>, IEnumerable<Veterinarian>>();

            CreateMap<Procedure, ProcedureDto>()
                .ForMember(d => d.EstimatedTime, opt => opt.MapFrom(s => s.EstimatedTime));
        }
    }
}
