using AutoMapper;
using VetClinic.Domain.Entities;
using VetClinic.Api.Dtos.Animal;
using VetClinic.Api.Dtos.Appointment;
using VetClinic.Api.Dtos.Owner;
using VetClinic.Api.Dtos.Veterinarian;

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

            CreateMap<Owner, OwnerDto>();
            CreateMap<CreateOwnerDto, Owner>();
            CreateMap<UpdateOwnerDto, Owner>();
            CreateMap<IEnumerable<OwnerDto>, IEnumerable<Owner>>();

            CreateMap<Veterinarian, VeterinarianDto>();
            CreateMap<CreateVeterinarianDto, Veterinarian>();
            CreateMap<UpdateVeterinarianDto, Veterinarian>();
            CreateMap<IEnumerable<VeterinarianDto>, IEnumerable<Veterinarian>>();

        }
    }
}
