using ManagmentVeterinary.Services;

namespace ManagmentVeterinary.Menu;

// Displays the main pet management menu and handles user interaction
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
                Console.WriteLine("4. Update Pet");
                Console.WriteLine("5. Delete Pet");
                Console.WriteLine("6. Try Veterinary Services");
                Console.WriteLine("7. Exit");
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
                        Console.Write("\nEnter pet ID to test services: ");
                        if (int.TryParse(Console.ReadLine(), out int petId))
                        {
                            PetService.TestVeterinaryService(petId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Exiting the Pet Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (opcion != 7);
        }
}