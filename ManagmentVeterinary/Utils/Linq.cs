using ManagmentVeterinary.Data;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Menu;

public class MenuLinq
{
    private static List<Pet> pets = Database.Pets;

    public void ShowMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- LINQ MENU ---");
            Console.WriteLine("1. Filter by species");
            Console.WriteLine("2. Select names");
            Console.WriteLine("3. Order by age");
            Console.WriteLine("4. Group by species");
            Console.WriteLine("5. Test basic methods");
            Console.WriteLine("6. Combined query");
            Console.WriteLine("7. Youngest and oldest");
            Console.WriteLine("8. Back to main menu");
            Console.Write("\nSelect an option: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Invalid option, please try again.");
                continue;
            }

            Console.Clear();

            if (pets.Count == 0 && opcion != 8)
            {
                Console.WriteLine("There are no pets registered.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    FilterBySpecies();
                    break;
                case 2:
                    SelectNames();
                    break;
                case 3:
                    OrderByAge();
                    break;
                case 4:
                    GroupBySpecies();
                    break;
                case 5:
                    TestBasicMethods();
                    break;
                case 6:
                    CombinedQuery();
                    break;
                case 7:
                    YoungestAndOldest();
                    break;
                case 8:
                    Console.WriteLine("Exiting LINQ menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        } while (opcion != 8);
    }

    private static void FilterBySpecies()
    {
        Console.Write("Enter species to filter: ");
        string species = Console.ReadLine()!.Trim();

        var result = pets.Where(p => p.Species.Equals(species, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"\nPets of species '{species}':");
        foreach (var p in result)
            Console.WriteLine(p);
    }

    private static void SelectNames()
    {
        var names = pets.Select(p => p.Name);
        Console.WriteLine("Pet names:");
        foreach (var n in names)
            Console.WriteLine(n);
    }

    private static void OrderByAge()
    {
        var order = pets.OrderBy(p => p.Age);
        Console.WriteLine("Pets ordered by age:");
        foreach (var p in order)
            Console.WriteLine($"{p.Name} - {p.Age} years");
    }

    private static void GroupBySpecies()
    {
        var group = pets.GroupBy(p => p.Species);
        foreach (var grupo in group)
        {
            Console.WriteLine($"\nSpecies: {grupo.Key}");
            foreach (var p in grupo)
                Console.WriteLine($" - {p.Name}");
        }
    }

    private static void TestBasicMethods()
    {
        var firstDog = pets.FirstOrDefault(p => p.Species == "Dog");
        Console.WriteLine($"First dog: {firstDog?.Name ?? "None"}");

        bool existsWithoutBreed = pets.Any(p => string.IsNullOrWhiteSpace(p.Breed));
        Console.WriteLine($"Any pet without breed? {existsWithoutBreed}");

        int countCats = pets.Count(p => p.Species == "Cat");
        Console.WriteLine($"Number of cats: {countCats}");
    }

    private static void CombinedQuery()
    {
        var resultado = pets
            .Where(p => p.Species == "Dog")
            .OrderBy(p => p.Age)
            .Select(p => new { p.Name, p.ClientId });

        foreach (var r in resultado)
            Console.WriteLine($"Owner {r.ClientId} - Pet: {r.Name}");
    }

    private static void YoungestAndOldest()
    {
        var young = pets.OrderBy(p => p.Age).First();
        var old = pets.OrderByDescending(p => p.Age).First();

        Console.WriteLine($"Youngest: {young.Name} ({young.Age} years)");
        Console.WriteLine($"Oldest: {old.Name} ({old.Age} years)");
    }
}
