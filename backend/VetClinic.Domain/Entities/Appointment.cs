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
        public ICollection<Procedure> Procedures { get; protected set; } = new HashSet<Procedure>();

        public List<Procedure> GetAllProcedures()
        {
            return Procedures == null 
                ? new List<Procedure>() 
                : Procedures.ToList();
        }

        public Procedure GetProcedureByCode(string code) 
        {
            return Procedures.FirstOrDefault(x => x.ProcedureCode == code) 
                ?? throw new InvalidOperationException("Could not find procedure with given code");
        }
        public void AddProcedure(Procedure procedure)
        {
            Procedures.Add(procedure);
        }

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
