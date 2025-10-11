using ManagmentVeterinary.Data;
using ManagmentVeterinary.Menu;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Repositories;

namespace ManagmentVeterinary.Services;

public class ConsultationService
{
    // Methods of crud with conect the database
    private static readonly ConsultationRepository _consultationRepository = new ConsultationRepository();
    private static readonly PetRepository _petRepository = new PetRepository();
    private static readonly VeterinarianRepository _veterinarianRepository = new VeterinarianRepository();
    
    // Method to add a consultation
    public static void AddConsultation()
    {
        Console.Clear();
        Console.WriteLine("\n--- Add Consultation ---");

        int? idPetNullable = BreakBucle.GetValidId("Pet", _petRepository.GetById);
        if (!idPetNullable.HasValue) 
        {
            Console.WriteLine("Consultation creation cancelled.");
            return;
        }
        int idPet = idPetNullable.Value;

        int? idVeterinarianNullable = BreakBucle.GetValidId("Veterinarian", _veterinarianRepository.GetById);
        if (!idVeterinarianNullable.HasValue) 
        {
            Console.WriteLine("Consultation creation cancelled.");
            return;
        }
        int idVeterinarian = idVeterinarianNullable.Value;

        // Show available dates
        DateTime dateOnly;
        while (true)
        {
            Console.Write("Enter date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out dateOnly))
            {
                // we validate that the date is not old
                if (dateOnly.Date >= DateTime.Now.Date) break;
                Console.WriteLine("You cannot schedule in the past.");
            }
            else Console.WriteLine("Invalid date format.");
        }

        // We show available hours
        var existingConsults = Database.Consultations
            .Where(c => c.VeterinarianId == idVeterinarian && c.Date.Date == dateOnly.Date)
            .Select(c => c.Date.TimeOfDay)
            .ToList();

        var freeHours = Database.AvailableHours.Except(existingConsults).ToList(); 

        // We validate that there are hours available
        if (!freeHours.Any())
        {
            Console.WriteLine("No available hours for that date.");
            return;
        }

        // We show available hours
        Console.WriteLine("\nAvailable Hours:");
        for (int i = 0; i < freeHours.Count; i++)
            Console.WriteLine($"{i + 1}. {freeHours[i]:hh\\:mm}");

        int choice;
        // We validate that the selected time is valid
        while (true)
        {
            Console.Write("Select hour: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= freeHours.Count)
                break;
            Console.WriteLine("Invalid option.");
        }
        
        // We add the selected date and time, to obtain the complete date and if you select it, it will not be repeated
        DateTime fullDate = dateOnly.Date + freeHours[choice - 1];
        
        Console.WriteLine("Symptoms: ");
        string? symptoms = Console.ReadLine();

        Console.WriteLine("Diagnosis: ");
        string? diagnosis = Console.ReadLine();

        Console.WriteLine("Treatment: ");
        string? treatment = Console.ReadLine();
        
        double cost;
        while (true)
        {
            Console.Write("Cost: ");
            if (double.TryParse(Console.ReadLine(), out cost) && cost >= 0)
                break;
            Console.WriteLine("Invalid cost. Please enter a valid number.");
        }
        
        try
        {
            var consultation = new Consultation(
                Database.GetNextConsultationId(),
                idPet,
                idVeterinarian,
                fullDate,
                symptoms ?? "N/A",
                diagnosis ?? "N/A",
                treatment ?? "N/A",
                cost
            );

            // We add the consultation to the database
            _consultationRepository.AddConsultation(consultation);
            Console.WriteLine($"\n Consultation scheduled successfully for {fullDate.ToString("dddd, dd/MM/yyyy")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n Error adding consultation: {ex.Message}");
        }
    }
    // Method to delete a consultation
    public static void DeleteConsultation()
    {
        Console.Clear();
        Console.WriteLine("\n--- Delete Consultation ---");

        Console.Write("Enter Consultation ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID invalid.");
            return;
        }
        // We delete the consultation from the database
        _consultationRepository.Delete(id);
        Console.WriteLine($"\n Consultation deleted successfully with ID: {id}");
    }
    // Method to update a consultation
    public static void UpdateConsultation()
    {
        Console.Clear();
        Console.WriteLine("\n--- Update Consultation ---");

        Console.Write("Enter Consultation ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID invalid.");
            return;
        }
        // We get the consultation from the database
        var consultation = _consultationRepository.GetById(id);
        if (consultation == null)
        {
            Console.WriteLine($"\nNo consultation found with ID {id}.");
            return;
        }

        Console.WriteLine("\nData consultation to update: ");
        Console.WriteLine(consultation);
        
        Console.WriteLine("\nPress ENTER to keep the current value.\n");
        
        Console.Write($"Symptoms ({consultation.Symptoms}): ");
        string? symptoms = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(symptoms))
            consultation.Symptoms = symptoms;

        Console.Write($"Diagnosis ({consultation.Diagnosis}): ");
        string? diagnosis = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(diagnosis))
            consultation.Diagnosis = diagnosis;

        Console.Write($"Treatment ({consultation.Treatment}): ");
        string? treatment = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(treatment))
            consultation.Treatment = treatment;
        
        Console.Write($"Cost ({consultation.Cost}): ");
        string? costInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(costInput))
        {
            if (double.TryParse(costInput, out double newCost) && newCost >= 0)
                consultation.Cost = newCost;
            else
                Console.WriteLine("Invalid cost. Value not updated.");
        }

        try
        {
            // We update the consultation in the database
            _consultationRepository.Update(consultation);
            Console.WriteLine($"\nConsultation updated successfully with ID: {id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n Error updating consultation: {ex.Message}");
        }
    }
    
    // Method to list all consultations
    public static void ListConsultations()
    {
        Console.Clear();
        Console.WriteLine("\n--- List Consultations ---");

        var consultations = _consultationRepository.GetAll();
        if (consultations.Count == 0)
        {
            Console.WriteLine("\nNo consultations found.");
            return;
        }

        foreach (var consultation in consultations)
        {
            // We get the pet and veterinarian from the database
            var pet = _petRepository.GetById(consultation.PetId);
            var vet = _veterinarianRepository.GetById(consultation.VeterinarianId);
            
            string petName = pet?.Name ?? "Unknown";
            string vetName = vet?.Name ?? "Unknown";
            
            string data = consultation.Date.ToString("dddd, dd/MM/yyyy") + " " + consultation.Date.ToString("HH:mm");
            string cost = consultation.Cost.ToString("C2"); // formato moneda
            
            Console.WriteLine($"{consultation.Id} | {petName} | {vetName} | {data} | {cost}");
        }
    }
    // Method to search a consultation
    public static void SearchConsultation()
    {
        Console.Clear();
        Console.WriteLine("\n--- Search Consultation ---");

        Console.Write("Enter Consultation ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID invalid.");
            return;
        }
        // We get the consultation from the database
        var consultation = _consultationRepository.GetById(id);
        if (consultation == null)
        {
            Console.WriteLine($"\nNo consultation found with ID {id}.");
            return;
        }

        Console.WriteLine("\nConsultation found:");
        Console.WriteLine(consultation);
    }
    
    
}