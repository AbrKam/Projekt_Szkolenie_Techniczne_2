using VetClinic.Domain.Entities;
using VetClinic.Domain.Enums;

namespace VetClinic.Domain.Query.Dtos
{
    public sealed record AnimalDto(Owner owner, string name, int age, AnimalSpecies species, string breed);
}
