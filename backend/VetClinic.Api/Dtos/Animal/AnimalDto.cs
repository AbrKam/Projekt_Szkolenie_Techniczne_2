using VetClinic.Domain.Enums;

namespace VetClinic.Api.Dtos.Animal
{
    public record AnimalDto(
        long Id, 
        long OwnerId, 
        string Name, 
        int Age, 
        string Species, 
        string Breed);
}
