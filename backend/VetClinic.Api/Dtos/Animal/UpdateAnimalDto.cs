namespace VetClinic.Api.Dtos.Animal
{
    public record UpdateAnimalDto(
        string Name,
        int Age,
        string Species,
        string Breed);
}
