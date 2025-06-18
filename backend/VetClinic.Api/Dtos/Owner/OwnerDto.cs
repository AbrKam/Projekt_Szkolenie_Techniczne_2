using VetClinic.Api.Dtos.Animal;

namespace VetClinic.Api.Dtos.Owner
{
    public record OwnerDto(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        IEnumerable<AnimalDto> Animals);
}
