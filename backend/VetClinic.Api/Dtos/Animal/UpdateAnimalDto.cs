using VetClinic.Domain.Enums;

namespace VetClinic.Api.Dtos.Animal
{
    public record UpdateAnimalDto(
        string Name,
        int Age,
        AnimalSpecies Species,
        string Breed);
}
