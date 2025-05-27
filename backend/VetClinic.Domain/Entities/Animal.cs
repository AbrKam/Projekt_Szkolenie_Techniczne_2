using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinic.Commons.Entities;
using VetClinic.Domain.Enums;

namespace VetClinic.Domain.Entities
{
    [Table("Animals", Schema = "Clinic")]
    public class Animal : BaseEntity
    {
        public Animal() { }

        public Animal(Owner owner, string name, int age, AnimalSpecies species, string breed) 
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Owner = owner;
            Name = name;
            Age = age;
            Species = species;
            Breed = breed;
        }

        [Required, MaxLength(50)]
        public string Name { get; protected set; }
        [Range(0, 50)]
        public int Age { get; protected set; }
        public AnimalSpecies Species { get; protected set; }
        [MaxLength(50)]
        public string Breed { get; protected set; }
        [Required]
        public long OwnerId { get; protected set; }
        public Owner Owner { get; protected set; }

        public void SetName(string name)
            => Name = name;
        public void SetAge(int  age)
            => Age = age;
        public AnimalSpecies SetSpecies(AnimalSpecies species)
            => Species = species;
        public void SetBreed(string breed)
            => Breed = breed;
    }
}
