using ManagmentVeterinary.Data;
using ManagmentVeterinary.Menu;
using ManagmentVeterinary.Repositories;

namespace ManagmentVeterinary.Models;

public class VeterinarianService
{
    // Methods of crud with conect the database
    private static readonly VeterinarianRepository _veterinarianRepository = new VeterinarianRepository();

    // Method to add a veterinarian
    public static void RegisterVeterinarian()
    {
        Console.Clear();
        Console.WriteLine("\n--- Add Veterinarian ---");

       var name = BreakBucle.GetStringOrCancel("Name");
       if (name == null) return;

       string? phone;
       do
       {
           phone = BreakBucle.GetStringOrCancel("Phone");
           if (phone == null) return;

           if (!phone.All(char.IsDigit) || phone.Length < 7)
           {
               Console.WriteLine("Invalid phone number. Must contain only digits and at least 7 numbers.");
               phone = null;
           }
       } while (phone == null);

       string? email;
       do
       {
           email = BreakBucle.GetStringOrCancel("Email");
           if (email == null) return;

           if (!email.Contains("@"))
           {
               Console.WriteLine("Invalid email format. It will be saved as empty.");
               email = null;
           }
       } while (email == null);

       var speciality = BreakBucle.GetStringOrCancel("Speciality");
       if (speciality == null) return;
       

        try
        {
            var veterinarian = new Veterinarian(Database.GetNextVeterinarianId(), name, phone, email, speciality);
            _veterinarianRepository.AddVeterinarian(veterinarian);
            Console.WriteLine($"\n Veterinarian '{name}' added successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError adding veterinarian: {ex.Message}");
        }
    }

    // Method to list a veterinarian
    public static void ListVeterinarians()
    {
        Console.Clear();
        Console.WriteLine("\n--- List Veterinarians ---");

        var veterinarians = _veterinarianRepository.GetAll();
        if (veterinarians.Count == 0)
        {
            Console.WriteLine("\nNo veterinarians found.");
            return;
        }

        foreach (var veterinarian in veterinarians)
        {
            Console.WriteLine(
                $"ID: {veterinarian.VeterinarianId} | Name: {veterinarian.Name} | Speciality: {veterinarian.Specialization}");
        }
    }

    // Method to search a veterinarian by id
    public static void SearchVeterinarianById()
    {
        Console.Clear();
        Console.WriteLine("\n--- Search Veterinarian by ID ---");

        Console.Write("Enter Veterinarian ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID is invalid. Should be a number.");
            return;
        }

        var veterinarian = _veterinarianRepository.GetById(id);
        if (veterinarian == null)
        {
            Console.WriteLine($"\nNo veterinarian found with ID {id}.");
            return;
        }

        // 
        Console.WriteLine($"\n--- Veterinarian Details (ID: {veterinarian.VeterinarianId}) ---");
        Console.WriteLine($"Name: {veterinarian.Name}");
        Console.WriteLine($"Phone: {veterinarian.Phone}");
        Console.WriteLine($"Email: {veterinarian.Email ?? "N/A"}");
        Console.WriteLine($"Speciality: {veterinarian.Specialization}");
        Console.WriteLine("---------------------------------------------\n");
    }

    // Method to update a veterinarian
    public static void UpdateVeterinarian()
    {
        Console.Clear();
        Console.WriteLine("\n--- Update Veterinarian ---");

        var idInput = BreakBucle.GetStringOrCancel("Enter veterinarian ID");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID invalid. It must be a number.");
            return;
        }

        // Use the Vet repository to obtain the object
        var veterinarian = _veterinarianRepository.GetById(id);
        if (veterinarian == null)
        {
            Console.WriteLine("\nVeterinarian not found.");
            return;
        }

        // We show the current data
        Console.WriteLine("\n Current Veterinarian Data:");
        Console.WriteLine(
            $"ID: {veterinarian.VeterinarianId} | Name: {veterinarian.Name} | Speciality: {veterinarian.Specialization}");

        Console.WriteLine("\nInsert new data (press Enter to keep the current value):");

        // Update
        var name = BreakBucle.GetStringOrCancel("New name", true);
        if (!string.IsNullOrWhiteSpace(name))
            veterinarian.Name = name; 

        var phone = BreakBucle.GetStringOrCancel("New phone", true);
        if (!string.IsNullOrWhiteSpace(phone))
            veterinarian.Phone = phone; 

        var email = BreakBucle.GetStringOrCancel("New email", true);
        if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
            veterinarian.Email = email;
        else if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            Console.WriteLine("Invalid email format. Keeping the current value.");

        var speciality = BreakBucle.GetStringOrCancel("New speciality", true);
        if (!string.IsNullOrWhiteSpace(speciality))
            veterinarian.Specialization = speciality; 

        try
        {
            // We call the Update method of the repository
            _veterinarianRepository.Update(veterinarian);
            Console.WriteLine($"\n Veterinarian updated successfully with ID: {veterinarian.VeterinarianId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n Error updating veterinarian: {ex.Message}");
        }
    }

    // Method to delete a veterinarian
    public static void DeleteVeterinarian()
    {
        Console.Clear();
        Console.WriteLine("\n--- Delete Veterinarian ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Enter veterinarian ID");
        if (idInput == null) return;
        
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID invalid. It must be a number.");
            return;
        }
        
        var veterinarian = _veterinarianRepository.GetById(id);
        if (veterinarian == null)
        {
            Console.WriteLine($"\nNo veterinarian found with ID {id}.");
            return;
        }
        
        // We ask the user for confirmation
        var confirm = BreakBucle.GetStringOrCancel("\nAre you sure you want to delete the following veterinarian?");
        Console.WriteLine($"ID: {veterinarian.VeterinarianId} | Name: {veterinarian.Name} | Speciality: {veterinarian.Specialization}");

        if (confirm != null && confirm.ToLower() == "y")
        {
            try
            {
                // elimination logic
                _veterinarianRepository.Delete(id); 
                Console.WriteLine($"\n Veterinarian with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError deleting veterinarian: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nDeletion cancelled.");
        }

        Console.WriteLine(veterinarian);
    }
}

