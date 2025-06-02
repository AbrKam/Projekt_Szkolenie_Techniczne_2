using System.ComponentModel.DataAnnotations;
using VetClinic.Commons.Entities;

namespace VetClinic.Domain.Entities
{
    public class Procedure : BaseEntity
    {
        private Procedure() { }
        internal Procedure(string procedureCode, decimal price, TimeSpan estimatedDuration, Veterinarian veterinarian, Animal animal)
        {
            ProcedureCode = procedureCode;
            Price = price;
            EstimatedTime = estimatedDuration;
            VeterinarianId = veterinarian.Id;
            AttendingVet = veterinarian;
            HandledAnimalId = animal.Id;
            HandledAnimal = animal;
            CreatedOn = DateTime.UtcNow;
        }

        [Required, StringLength(10)]
        public string ProcedureCode { get; protected set; }
        public decimal Price { get; protected set; }
        public TimeSpan EstimatedTime { get; protected set; }

        [Required] public long VeterinarianId { get; protected set; }
        [Required] public Veterinarian AttendingVet { get; protected set; }
        [Required] public long HandledAnimalId { get; protected set; }
        [Required] public Animal HandledAnimal { get; protected set; }

        public void SetProcedureCode(string procedureCode) 
            => ProcedureCode = procedureCode;
        public void SetPrice(decimal price) 
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative");
            Price = price;
        }
        public void SetVeterinarian(Veterinarian veterinarian)
            => AttendingVet = veterinarian;
        public void SetHandledAnimal(Animal animal)
            => HandledAnimal = animal;
    }
}
