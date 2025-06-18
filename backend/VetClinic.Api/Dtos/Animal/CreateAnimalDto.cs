namespace VetClinic.Api.Dtos.Animal
{
    public record CreateAnimalDto(
        long OwnerId,
        string Name,
        int Age,
        string Species,
        string Breed);
}
