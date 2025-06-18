using VetClinic.Domain.Enums;

namespace VetClinic.Api.Dtos.Veterinarian
{
    public record VeterinarianDto(long Id, 
        string FirstName, 
        string LastName, 
        string Email, 
        string PhoneNumber, 
        string Speciality);
}
