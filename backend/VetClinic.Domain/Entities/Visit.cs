using System.ComponentModel.DataAnnotations.Schema;
using VetClinic.Commons.Entities;

namespace VetClinic.Domain.Entities
{
    [Table("Visits", Schema = "Clinic")]
    public class Visit : BaseEntity
    {
        public string Purpose { get; protected set; }
        public string Description { get; protected set; }

    }
}
