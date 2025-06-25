using VetClinic.Domain.Enums;

namespace VetClinic.Api.Dtos.Animal
{
    public record CreateAnimalDto(
        long OwnerId,
        string Name,
        int Age,
        AnimalSpecies Species,
        string Breed);
}
