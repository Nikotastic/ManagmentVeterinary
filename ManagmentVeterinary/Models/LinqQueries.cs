namespace ManagmentVeterinary.Models;

public class LinqQueries
{
   // Filtrar mascotas por especie
        public static void FilterPetsBySpecies(List<Patient> owners, string Species)
        {
            if (string.IsNullOrEmpty(Species))
            {
                Console.WriteLine("Please enter a valid species.");
                return;
            }
            if (owners.Count == 0)
            {
                Console.WriteLine("No owners registered yet.");
                return;
            }
            
            var result = owners
                .SelectMany(o => o.Pets, (o, pet) => new { Owner = o, Pet = pet })
                .Where(op => op.Pet.Species.Equals(Species, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nSpecies pets '{Species}':");
            foreach (var item in result)
            {
                Console.WriteLine($"Pet: {item.Pet.Name} ({item.Pet.Species}) - Owner: {item.Owner.Name}");
            }
        }

        // Mostrar solo nombres de mascotas
        public static void ShowPetsNames(List<Patient> owners)
        {
            var names = owners.SelectMany(o => o.Pets.Select(p => p.Name));

            Console.WriteLine("\nNames of all registered pets:");
            foreach (var name in names)
            {
                Console.WriteLine($"- {name}");
            }
        }

        // Ordenar mascotas por edad (menor a mayor)
        public static void OrderPetsByAge(List<Patient> owners)
        {
            var Ordered = owners
                .SelectMany(o => o.Pets, (o, pet) => new { o.Name, Pet = pet })
                .OrderBy(x => x.Pet.Age);

            Console.WriteLine("\nPets ordered by age:");
            foreach (var item in Ordered)
            {
                Console.WriteLine($"Pets: {item.Pet.Name} ({item.Pet.Age} years) - Owner: {item.Name}");
            }
        }

        // Agrupar mascotas por especie
        public static void GroupPetsBySpecies(List<Patient> owners)
        {
            var groups = owners
                .SelectMany(o => o.Pets)
                .GroupBy(p => p.Species);

            Console.WriteLine("\nPets grouped by species:");
            foreach (var group in groups)
            {
                Console.WriteLine($"\nSpecie: {group.Key}");
                foreach (var pet in group)
                {
                    Console.WriteLine($"- {pet.Name} ({pet.Age} years)");
                }
            }
        }

        // Encontrar la mascota más joven
        public static void YoungestPet(List<Patient> owners)
        {
            var all = owners.SelectMany(o => o.Pets);
            var young = all.OrderBy(p => p.Age).FirstOrDefault();

            if (young != null)
                Console.WriteLine($"\nThe youngest pet is {young.Name} ({young.Age} years) - Specie: {young.Species}");
            else
                Console.WriteLine("\nThere are no registered pets.");
        }

        // Contar mascotas por especie
        public static void CountPetsBySpecies(List<Patient> owners)
        {
            var counting = owners
                .SelectMany(o => o.Pets)
                .GroupBy(p => p.Species)
                .Select(g => new { Specie = g.Key, Amount = g.Count() });

            Console.WriteLine("\nAmount of pets per species:");
            foreach (var group in counting)
            {
                Console.WriteLine($"- {group.Specie}: {group.Amount}");
            }
        }
}
    