using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using VetClinic.Commons.Entities;
using VetClinic.Domain.Enums;

namespace VetClinic.Domain.Entities
{
    [Table("Onwers", Schema = "Clinic")]
    public class Owner : BaseEntity
    {
        public Owner() { }

        public Owner(string firstName, string lastName, string email, string phoneNumber) 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        [Required, MaxLength(50)]
        public string FirstName { get; protected set;}
        [Required, MaxLength(50)]
        public string LastName { get; protected set;}
        [Required, MaxLength(256)]
        public string Email { get; protected set;}
        [Required, MaxLength(12)]
        public string PhoneNumber {  get; protected set;}

        public virtual ICollection<Animal> Animals { get; protected set;} = new HashSet<Animal>();

        public void SetFirstName(string firstName)
            => FirstName = firstName;
        public void SetLastName(string lastName)
            => LastName = lastName;
        public void SetEmail(string email)
                    => Email = email;
        public void SetPhoneNumber(string phoneNumber)
                    => PhoneNumber = phoneNumber;

        public Animal GetAnimalById(long id) 
        {
            return Animals.Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Animal> GetAllAnimals() 
        {
            return Animals == null? new List<Animal>() 
                : Animals.ToList();
        }

        public void AddAnimal(string name, int age, AnimalSpecies species, string breed)
            => Animals.Add(new Animal(this, name, age, species, breed));
        public void UpdateAnimal(long animalId, string newName, int newAge)
        {
            Animal animal = GetAnimalById(animalId)
                ?? throw new NullReferenceException("Animal not found");
            animal.SetName(newName);
            animal.SetAge(newAge);
        }

        public void RemoveAnimal(long animalId)
        {
            Animal animal = GetAnimalById(animalId) 
                ?? throw new NullReferenceException("Animal not found");
            Animals.Remove(animal);
        }
    }
}
