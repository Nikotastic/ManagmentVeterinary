using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Repositories;

namespace ManagmentVeterinary.Services;

public class PetService
{
    private readonly IPetRepository _petRepository;
    private readonly IPatientRepository _patientRepository;

    public PetService()
    {
        _petRepository = new PetRepository();
        _patientRepository = new PatientRepository();
    }

    // Metodo para agregar mascota a paciente
    public void AddPet()
    {
        Console.WriteLine("\n--- Add Pet ---");
        Console.Write("Enter patient ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Invalid patient ID.");
            return;
        }

        var patient = _patientRepository.GetById(patientId);
        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        Console.Write("Enter pet name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter pet species: ");
        string species = Console.ReadLine()!;
        
        Console.Write("Enter pet age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age.");
            return;
        }
        
        Console.Write("Symptom: ");
        string symptom = Console.ReadLine()!;

        var pet = new Pet(name, species, age, symptom);
        _petRepository.Add(patientId, pet);
        
        Console.WriteLine("Pet added successfully");
    }
    // Metodo para eliminar mascota de paciente
    public void RemovePet()
    {
        Console.WriteLine("\n--- Delete Pet ---");
        Console.Write("Enter patient ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Invalid patient ID.");
            return;
        }

        if (_patientRepository.GetById(patientId) == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        Console.Write("Enter pet name: ");
        string name = Console.ReadLine()!;

        _petRepository.Delete(patientId, name);
        Console.WriteLine($"Pet {name} deleted successfully");
    }

    public void UpdatePet()
    {
        Console.WriteLine("\n--- Update Pet ---");
        Console.Write("Enter patient ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Invalid patient ID.");
            return;
        }

        if (_patientRepository.GetById(patientId) == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        Console.Write("Enter pet name: ");
        string name = Console.ReadLine()!;

        var existingPet = _petRepository.GetByName(patientId, name);
        if (existingPet == null)
        {
            Console.WriteLine($"Pet {name} not found for patient {patientId}");
            return;
        }

        Console.Write("Enter new pet name (press Enter to keep current): ");
        string newName = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newName))
            existingPet.Name = newName;

        Console.Write("Enter new species (press Enter to keep current): ");
        string newSpecies = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newSpecies))
            existingPet.Species = newSpecies;

        Console.Write("Enter new age (press Enter to keep current): ");
        string newAgeInput = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newAgeInput) && int.TryParse(newAgeInput, out int newAge))
            existingPet.Age = newAge;
        
        Console.Write("Enter new symptom (press Enter to keep current): ");
        string newSymptom = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newSymptom))
            existingPet.Symptom = newSymptom;

        _petRepository.Update(patientId, existingPet);
        Console.WriteLine("Pet updated successfully");
    }
}