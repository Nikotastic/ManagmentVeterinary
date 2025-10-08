namespace ManagmentVeterinary.Menu;

public class MenuMain
{
    public void ShowMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENU PRINCIPAL ---");
            Console.WriteLine("1. Clientes");
            Console.WriteLine("2. Mascotas");
            Console.WriteLine("3. Salir");
            Console.Write("\nSeleccione una opción: ");

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
                    Console.WriteLine("Saliendo del menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 3);
    }
}