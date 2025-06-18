namespace VetClinic.Api.Dtos.Owner
{
    public record CreateOwnerDto( 
        string FirstName, 
        string LastName, 
        string Email, 
        string PhoneNumber);
}
