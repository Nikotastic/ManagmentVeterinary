using ManagmentVeterinary.Services;

namespace ManagmentVeterinary.Menu;

public class MenuPet
{
        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- MENU PETS ---");
                Console.WriteLine("1. Register Pet");
                Console.WriteLine("2. List Pets");
                Console.WriteLine("3. Search Pet");
                Console.WriteLine("4. Delete Pet");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Invalid option, please try again.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        PetService.AddPet();
                        break;
                    case 2:
                        PetService.ListPets();
                        break;
                    case 3:
                        PetService.SearchPet();
                        break;
                    case 4:
                        PetService.UpdatePet();
                        break;
                    case 5:
                        PetService.DeletePet();
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