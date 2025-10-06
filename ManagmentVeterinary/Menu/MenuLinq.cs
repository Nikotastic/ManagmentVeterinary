using ManagmentVeterinary.Models;
namespace ManagmentVeterinary.Menu;

public class MenuLinq
{
    public static void ShowMenuLinq(List<Patient> patients)
    {
        string opcion;
        do
        {
            Console.WriteLine("\n=== LINQ MENU ===");
            Console.WriteLine(@"1. Filter Pets By Species
2 Show Pets Names
3. Order Pets By Age
4. Group Pets By Species
5. Youngest Pet
6.  Count Pets By Species
7. Go to the main menu");
            Console.Write("Choose an option: ");
            opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    Console.Write("Enter the species: ");
                    string especie = Console.ReadLine()!;
                    LinqQueries.FilterPetsBySpecies(patients, especie);
                    break;

                case "2":
                    LinqQueries.ShowPetsNames(patients);
                    break;

                case "3":
                    LinqQueries.OrderPetsByAge(patients);
                    break;

                case "4":
                    LinqQueries.GroupPetsBySpecies(patients);
                    break;

                case "5":
                    LinqQueries.YoungestPet(patients);
                    break;

                case "6":
                    LinqQueries. CountPetsBySpecies(patients);
                    break;

                case "7":
                    Console.WriteLine("Returning to the main menu ...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

        } while (opcion != "7");
    }
}
