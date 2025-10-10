using ManagmentVeterinary.Services;

namespace ManagmentVeterinary.Menu;

// Displays the main consultation management menu and handles user interaction
public class MenuConsultation
{
    public void ShowMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENU CONSULTATION ---");
            Console.WriteLine("1. Register Consultation");
            Console.WriteLine("2. List Consultation");
            Console.WriteLine("3. Search Consultation");
            Console.WriteLine("4. Update Consultation");
            Console.WriteLine("5. Delete Consultation");
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
                    ConsultationService.AddConsultation();
                    break;
                case 2:
                    ConsultationService.ListConsultations();
                    break;
                case 3:
                    ConsultationService.SearchConsultation();
                    break;
                case 4:
                    ConsultationService.UpdateConsultation();
                    break;
                case 5:
                    ConsultationService.DeleteConsultation();
                    break;
                case 6:
                    Console.WriteLine("Exiting the Consultation Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        } while (opcion != 6);
    }
}