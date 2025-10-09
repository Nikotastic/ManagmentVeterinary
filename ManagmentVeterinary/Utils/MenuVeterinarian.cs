using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Menu;

public class MenuVeterinarian
{
    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENU PETS ---");
            Console.WriteLine("1. Register Vet");
            Console.WriteLine("2. List Vet");
            Console.WriteLine("3. Search Vet");
            Console.WriteLine("4. Update Vet");
            Console.WriteLine("5. Delete Vet");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect an option: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Invalid option, please try again.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    VeterinarianService.RegisterVeterinarian();
                    break;
                case 2:
                    VeterinarianService.ListVeterinarians();
                    break;
                case 3:
                    VeterinarianService.SearchVeterinarianById();
                    break;
                case 4:
                    VeterinarianService.UpdateVeterinarian();
                    break;
                case 5:
                    VeterinarianService. DeleteVeterinarian();
                    break;
                case 6:
                    Console.WriteLine("Exiting the Pet Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        } while (opcion != 6);
    }
}