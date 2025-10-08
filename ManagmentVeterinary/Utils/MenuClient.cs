using ManagmentVeterinary.Services;
namespace ManagmentVeterinary.Menu;

public class MenuClient
{

    // Muestra el menú principal de gestión de pacientes y maneja la interacción del usuario
    public void ShowMenu()
    {
        bool exit = false;

        while (!exit)
        {
            
            Console.WriteLine("\n=== MENU CLIENT ===");
            Console.WriteLine("1. Register client");
            Console.WriteLine("2. List client");
            Console.WriteLine("3. Search client by ID");
            Console.WriteLine("4. Update client");
            Console.WriteLine("5. Delete client");
            Console.WriteLine("6. Agregar mascota a paciente");
            Console.WriteLine("0. Back to main menu");
            Console.Write("\nSeleccione una opción: ");
            

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ClientService.RegisterClient();
                    break;
                case "2":
                    ClientService.ListClients();
                    break;
                case "3":
                    ClientService.SearchClientById();
                    break;
                case "4":
                    ClientService.UpdateClient();
                    break;
                case "5":
                    ClientService.DeleteClient();
                    break;
                case "6":
                   ClientService.AddPetToPatient();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nOption invalid. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}