using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinic.Commons.Entities;

namespace VetClinic.Domain.Entities
{
    [Table("Visits", Schema = "Clinic")]
    public class Appointment : BaseEntity
    {
        public Appointment() {CreatedOn = DateTime.UtcNow;}
        public Appointment(string purpose, string description, Veterinarian veterinarian, Animal animal)
        {
            Purpose = purpose;
            Description = description;
            Veterinarian = veterinarian;
            Animal = animal;
            CreatedOn = DateTime.UtcNow;
        }

        public string Purpose { get; protected set; }
        public string Description { get; protected set; }
        [Required] public long VeterinarianId { get; protected set; }
        [Required] public Veterinarian Veterinarian { get; protected set; }
        [Required] public long AnimalId { get; protected set; }
        [Required] public Animal Animal { get; protected set; }

        public void SetPurpose(string purpose)
            => Purpose = purpose;
        public void SetDescription(string description)
            => Description = description;
        public void SetVeterinarian(Veterinarian veterinarian)
            => Veterinarian = veterinarian;
        public void SetAnimal(Animal animal)
            => Animal = animal;
    }
}
