using System.Collections;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Repositories;

namespace ManagmentVeterinary.Services;

public class PetService
{
    private static readonly PetRepository _petRepository = new PetRepository();
    private static readonly ClientRepository _clientRepository = new ClientRepository();
    
    public static void AddPet()
    {
        Console.Clear();
        Console.WriteLine("\n--- Add Pet ---");

        int idClient;
        while (true)
        {
            Console.Write("Insert ID Client: ");
            if (int.TryParse(Console.ReadLine(), out idClient))
            {
                var client = _clientRepository.GetById(idClient);
                if (client != null)
                    break;
                else
                    Console.WriteLine($"No client found with ID {idClient}. Try again.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a numeric value.");
            }
        }

        string name;
        while (true)
        {
            Console.Write("Name: ");
            name = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(name)) break;
            Console.WriteLine("Name cannot be empty.");
        }

        string species;
        while (true)
        {
            Console.Write("Species: ");
            species = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(species)) break;
            Console.WriteLine("Species cannot be empty.");
        }

        string breed;
        while (true)
        {
            Console.Write("Breed: ");
            breed = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(breed)) break;
            Console.WriteLine("Breed cannot be empty.");
        }

        int age;
        while (true)
        {
            Console.Write("Age: ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                break;
            Console.WriteLine("Invalid age. Enter a positive number.");
        }

        Console.Write("Symptom: ");
        string? symptom = Console.ReadLine();

        string sexo;
        while (true)
        {
            Console.Write("Sex (M/F): ");
            sexo = Console.ReadLine()!.ToUpper();
            if (sexo == "M" || sexo == "F")
                break;
            Console.WriteLine("Invalid sex. Enter 'M' or 'F'.");
        }

        try
        {
            var pet = new Pet(idClient, name, age, species, breed, symptom, idClient, sexo);
            _petRepository.AddPet(pet);
            Console.WriteLine($"\n Pet '{name}' added successfully for client ID {idClient}.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError adding pet: {ex.Message}");
        }
    }
    
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
    
    public static void SearchPet()
    {
        Console.WriteLine("\n--- Search Pet by ID ---");
        Console.Write("Enter Pet ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

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
    }
    
    public static void UpdatePet()
    {
        Console.WriteLine("\n--- Update Pet by ID ---");
        Console.Write("Enter Pet ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

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

        Console.Write("Enter new name: ");
        pet.Name = Console.ReadLine()!;

        Console.Write("Enter new species: ");
        pet.Species = Console.ReadLine()!;

        Console.Write("Enter new breed: ");
        pet.Breed = Console.ReadLine()!;

        Console.Write("Enter new age: ");
        pet.Age = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter new symptom: ");
        pet.Symptom = Console.ReadLine();

        Console.Write("Enter new sex (M/F): ");
        pet.Sexo = Console.ReadLine()!.ToUpper();

        _petRepository.Update(pet);
        Console.WriteLine($"\nPet '{pet.Name}' updated successfully.");
    }
    
    public static void DeletePet()
    {
        Console.WriteLine("\n--- Delete Pet by ID ---");
        Console.Write("Enter Pet ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var pet = _petRepository.GetById(id);

        if (pet == null)
        {
            Console.WriteLine($"No pet found with ID {id}.");
            return;
        }

        _petRepository.Delete(id);
        Console.WriteLine($"\nPet '{pet.Name}' deleted successfully.");
    }
}