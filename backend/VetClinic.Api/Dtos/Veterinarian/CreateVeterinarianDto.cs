namespace VetClinic.Api.Dtos.Veterinarian
{
    public record CreateVeterinarianDto(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Speciality);
}
