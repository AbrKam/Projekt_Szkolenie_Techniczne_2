using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinic.Commons.Entities;
using VetClinic.Domain.Enums;

namespace VetClinic.Domain.Entities
{
    [Table("Veterinarians", Schema = "Clinic")]
    public class Veterinarian : BaseEntity
    {
        public Veterinarian() { }

        public Veterinarian(string firstName, string lastName, string email, string phoneNumber, VeterinarianSpeciality speciality)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Speciality = speciality;
        }

        [Required, MaxLength(50)]
        public string FirstName { get; protected set; }
        [Required, MaxLength(50)]
        public string LastName { get; protected set; }
        [Required, MaxLength(256)]
        public string Email { get; protected set; }
        [Required, MaxLength(12)]
        public string PhoneNumber { get; protected set; }
        public VeterinarianSpeciality Speciality { get; protected set; }

        public void SetFirstName(string firstName)
            => FirstName = firstName;
        public void SetLastName(string lastName)
            => LastName = lastName;
        public void SetEmail(string email)
            => Email = email;
        public void SetPhoneNumber(string phoneNumber)
            => PhoneNumber = phoneNumber;
        public void SetSpeciality(VeterinarianSpeciality speciality)
            => Speciality = speciality;
    }
}
