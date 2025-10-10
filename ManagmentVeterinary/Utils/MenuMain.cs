namespace ManagmentVeterinary.Menu;

public class MenuMain
{
    public void ShowMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MAIN MENU ---");
            Console.WriteLine("1. Clients");
            Console.WriteLine("2. Pets");
            Console.WriteLine("3. Veterinaries");
            Console.WriteLine("4. Consultation");
            Console.WriteLine("5. LINQ");
            Console.WriteLine("6. Salir");
            Console.Write("\nSelect a option: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Invalid option, please try again.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    MenuClient menuClient = new MenuClient();
                    menuClient.ShowMenu();
                    break;
                case 2:
                    MenuPet menuPet = new MenuPet();
                    menuPet.MostrarMenu();
                    break;
                case 3:
                    MenuVeterinarian menuVeterinarian = new MenuVeterinarian();
                    menuVeterinarian.MostrarMenu();
                    break;
                case 4:
                    MenuConsultation menuConsultation = new MenuConsultation();
                    menuConsultation.ShowMenu();
                    break;
                case 5:
                    new MenuLinq().ShowMenu();
                    break;
                case 6:
                    Console.WriteLine("Exiting the main menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option."); 
                    break;
            }
        } while (opcion != 6);
    }
}