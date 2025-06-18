namespace VetClinic.Api.Dtos.Owner
{
    public record UpdateOwnerDto(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber);
}
