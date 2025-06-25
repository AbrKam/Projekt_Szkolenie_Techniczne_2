using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VetClinic.Domain.Entities;
using VetClinic.Domain.Enums;

namespace VetClinic.Infrastructure.Database
{
    public static class DbInitializer
    {
        public class ProcedureDefaultConfig
        {
            public string Code { get; set; } = null!;
            public TimeSpan EstimatedDuration { get; set; }
            public decimal Price { get; set; }
        }

        public static void Initialize(ClinicDbContext context, IConfiguration config)
        {
            context.Database.Migrate();

            if (context.Owners.Any()) return;

            var procDefs = config
              .GetSection("ProcedureDefaults:Items")
              .Get<List<ProcedureDefaultConfig>>()
              ?? new List<ProcedureDefaultConfig>();

            var owner1 = new Owner("John", "Kovalsky", "j.kovalsky@vetclinic.com", "123456789");
            var owner2 = new Owner("Anna", "Novack", "a.novack@vetclinic.com", "987654321");
            context.Owners.AddRange(owner1, owner2);

            var vet1 = new Veterinarian("Pavlo", "Zhioowcovsky", "p.zhioowcovksy@vetclinic.com", "111222333", VeterinarianSpeciality.General);
            var vet2 = new Veterinarian("Eve", "Zieleenska", "e.zieleenska@vetclinic.com", "444555666", VeterinarianSpeciality.Surgery);
            context.Veterinarians.AddRange(vet1, vet2);

            var animal1 = new Animal(owner1, "Louis", 4, AnimalSpecies.Dog, "Kundel");
            var animal2 = new Animal(owner2, "Rigby", 2, AnimalSpecies.Cat, "Dachowiec");
            context.Animals.AddRange(animal1, animal2);

            var appts = new List<Appointment>();

            var appt1 = new Appointment(
                purpose: "Coroczne szczepienie",
                description: "Szczepienie przeciw wściekliźnie",
                veterinarian: vet1,
                animal: animal1
            );
            if (procDefs.Count() >= 1)
            {
                var d = procDefs[0];
                appt1.AddProcedure(new Procedure(
                    procedureCode: d.Code,
                    price: d.Price,
                    estimatedDuration: d.EstimatedDuration,
                    veterinarian: vet1,
                    animal: animal1
                ));
            }

            var appt2 = new Appointment(
                purpose: "Kontrola zdrowia",
                description: "Ogólne badanie i odrobaczanie",
                veterinarian: vet2,
                animal: animal2
            );
            if (procDefs.Count() >= 2)
            {
                var d = procDefs[1];
                appt2.AddProcedure(new Procedure(
                    procedureCode: d.Code,
                    price: d.Price,
                    estimatedDuration: d.EstimatedDuration,
                    veterinarian: vet2,
                    animal: animal2
                ));
            }

            context.Appointments.AddRange(appt1, appt2);

            context.SaveChanges();
        }
    }
}
