using System.Collections;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Menu;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Repositories;

namespace ManagmentVeterinary.Services;

public class PetService
{
    // Methods of crud with conect the database
    private static readonly PetRepository _petRepository = new PetRepository();
    private static readonly ClientRepository _clientRepository = new ClientRepository();
    
    // Method to add a pet
    public static void AddPet()
    {
        Console.Clear();
        Console.WriteLine("\n--- Add Pet ---");

        var clientIdInput = BreakBucle.GetStringOrCancel("Insert ID Client");
        if (clientIdInput == null) return;

        if (!int.TryParse(clientIdInput, out int idClient))
        {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            return;
        }

        var client = _clientRepository.GetById(idClient);
        if (client == null)
        {
            Console.WriteLine($"No client found with ID {idClient}.");
            return;
        }

        var name = BreakBucle.GetStringOrCancel("Enter pet name");
        if (name == null) return;

        var species = BreakBucle.GetStringOrCancel("Enter species");
        if (species == null) return;

        var breed = BreakBucle.GetStringOrCancel("Enter breed");
        if (breed == null) return;

        var ageInput = BreakBucle.GetStringOrCancel("Enter age");
        if (ageInput == null) return;

        if (!int.TryParse(ageInput, out int age) || age <= 0)
        {
            Console.WriteLine("Invalid age. Must be a positive number.");
            return;
        }

        var symptom = BreakBucle.GetStringOrCancel("Enter symptoms (optional)", true);
        if (symptom == null) return;

        string? sex;
        do
        {
            sex = BreakBucle.GetStringOrCancel("Enter sex (M/F)");
            if (sex == null) return;
            
            sex = sex.ToUpper();
            if (sex != "M" && sex != "F")
            {
                Console.WriteLine("Invalid sex. Must be 'M' or 'F'.");
                sex = null;
            }
        } while (sex == null);

        try
        {
            var pet = new Pet(idClient, name, age, species, breed, symptom, idClient, sexo: sex);
            _petRepository.AddPet(pet);
            Console.WriteLine($"\nPet '{name}' added successfully for client ID {idClient}.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError adding pet: {ex.Message}");
        }
    }
    
    // Method to List a pet
    public static void ListPets()
    {
        var pets = _petRepository.ListPets();
        Console.WriteLine("\n--- List of Pets ---");
        if (pets.Any())
        {
            foreach (var pet in pets)
            {
                
                Console.WriteLine(pet.ToString());
            }
        }
        else
        {
            Console.WriteLine("No Pets registered yet.");
        }
    }
    
    // Method to Search a pet
    public static void SearchPet()
    {
        Console.WriteLine("\n--- Search Pet by ID ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Enter Pet ID");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            return;
        }

        var pet = _petRepository.GetById(id);
        if (pet == null)
        {
            Console.WriteLine($"No pet found with ID {id}.");
            return;
        }

        Console.WriteLine("\nPet found:");
        Console.WriteLine($"- ID: {pet.Id}");
        Console.WriteLine($"- Name: {pet.Name}");
        Console.WriteLine($"- Species: {pet.Species}");
        Console.WriteLine($"- Breed: {pet.Breed}");
        Console.WriteLine($"- Age: {pet.Age}");
        Console.WriteLine($"- Symptom: {pet.Symptom}");
        Console.WriteLine($"- Sex: {pet.Sexo}");

        // Show owner information if it exists
        if (pet.ClientId != null)
        {
            var client = _clientRepository.GetById(pet.ClientId);
            if (client != null)
                Console.WriteLine($"- Owner: {client.Name} (ID: {client.IdClient})");
            else
                Console.WriteLine("- Owner: Sin dueño");
        }
        else
        {
            Console.WriteLine("- Owner: Sin dueño");
        }
    }
    // Method to Update a pet
    public static void UpdatePet()
    {
        Console.WriteLine("\n--- Update Pet by ID ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Enter Pet ID");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            return;
        }

        var pet = _petRepository.GetById(id);
        if (pet == null)
        {
            Console.WriteLine($"No pet found with ID {id}.");
            return;
        }

        Console.WriteLine("\nCurrent Pet Data:");
        Console.WriteLine($"- ID: {pet.Id}");
        Console.WriteLine($"- Name: {pet.Name}");
        Console.WriteLine($"- Species: {pet.Species}");
        Console.WriteLine($"- Breed: {pet.Breed}");
        Console.WriteLine($"- Age: {pet.Age}");
        Console.WriteLine($"- Symptom: {pet.Symptom}");
        Console.WriteLine($"- Sex: {pet.Sexo}");

        Console.WriteLine("\nEnter new data (press Enter to keep current value):");

        var newName = BreakBucle.GetStringOrCancel("New name", true);
        if (newName == null) return;
        if (!string.IsNullOrWhiteSpace(newName))
            pet.Name = newName;

        var newSpecies = BreakBucle.GetStringOrCancel("New species", true);
        if (newSpecies == null) return;
        if (!string.IsNullOrWhiteSpace(newSpecies))
            pet.Species = newSpecies;

        var newBreed = BreakBucle.GetStringOrCancel("New breed", true);
        if (newBreed == null) return;
        if (!string.IsNullOrWhiteSpace(newBreed))
            pet.Breed = newBreed;

        var newAge = BreakBucle.GetStringOrCancel("New age", true);
        if (newAge == null) return;
        if (!string.IsNullOrWhiteSpace(newAge))
        {
            if (int.TryParse(newAge, out int age) && age > 0)
                pet.Age = age;
            else
                Console.WriteLine("Invalid age. Keeping current age.");
        }

        var newSymptom = BreakBucle.GetStringOrCancel("New symptom", true);
        if (newSymptom == null) return;
        pet.Symptom = newSymptom; // Puede ser null

        string? newSex;
        if (BreakBucle.GetStringOrCancel("New sex (M/F or press Enter to keep current)", true) is string sexInput)
        {
            if (!string.IsNullOrWhiteSpace(sexInput))
            {
                sexInput = sexInput.ToUpper();
                if (sexInput == "M" || sexInput == "F")
                    pet.Sexo = sexInput;
                else
                    Console.WriteLine("Invalid sex. Keeping current sex.");
            }
        }
        else return;

        _petRepository.Update(pet);
        Console.WriteLine($"\nPet '{pet.Name}' updated successfully.");
    }
    
    // Method to Delete a pet
    public static void DeletePet()
    {
        Console.WriteLine("\n--- Delete Pet by ID ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Enter Pet ID");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            return;
        }

        var pet = _petRepository.GetById(id);
        if (pet == null)
        {
            Console.WriteLine($"No pet found with ID {id}.");
            return;
        }

        Console.WriteLine("\nPet to delete:");
        Console.WriteLine($"- ID: {pet.Id}");
        Console.WriteLine($"- Name: {pet.Name}");
        Console.WriteLine($"- Species: {pet.Species}");
        Console.WriteLine($"- Breed: {pet.Breed}");

        var confirm = BreakBucle.GetStringOrCancel("Are you sure you want to delete this pet? (y/n)");
        if (confirm == null || confirm.ToLower() != "y")
        {
            Console.WriteLine("\nOperation canceled.");
            return;
        }

        _petRepository.Delete(id);
        Console.WriteLine($"\nPet '{pet.Name}' deleted successfully.");
    }
    
    // Method to Test a pet
    public static void TestVeterinaryService(int petId)
    {
        var pet = _petRepository.GetById(petId);
        if (pet == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        // Testing polymorphism with animal sound
        Console.WriteLine($"\nTesting sounds of {pet.Name}:");
        Console.WriteLine($"The pet does: {pet.IssueSound()}");

        // Trying different veterinary services
        Console.WriteLine("\nTrying different veterinary services:");
        
        // General Consultation
        var consultation = new GeneralConsultation(1, "Routine consultation", 50.0m, "General healthy condition");
        consultation.Attend(pet);

        // Vaccination
        var vacunation = new Vacunation(2, "Annual vaccination", 75.0m, "Rabies vaccine", DateTime.Now.AddYears(1));
        vacunation.Attend(pet);

        // Testing the registry
        Console.WriteLine("\nTesting registration:");
        pet.Register();
    }
}