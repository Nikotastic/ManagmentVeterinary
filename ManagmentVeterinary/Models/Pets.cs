using ManagmentVeterinary.Interfaces;

namespace ManagmentVeterinary.Models;

// class for the pet and implements the interfaces IssueSound, INotification and IRegistrable
public class Pet: Animal, INotification, IRegistrable
{
    public int Id { get; private set; }
    public string Breed { get; set; }
    public string? Symptom { get; set; }
    public int ClientId { get; set; }
    
    
    public Pet(int id, string name, int age, string species, string breed, string? symptom, int clientId, string sexo) : base(name, age, species, sexo)
    {
        Id = id;
        Breed = breed;
        Symptom = symptom;
        ClientId = clientId;
        Sexo = sexo;
    }
    

    public void SendNotification(string message)
    {
        Console.WriteLine($"[Owner notification {Name}]: {message}");
    }

    public override string IssueSound()
    {
        var sp = Species.ToLowerInvariant();
        if (sp.Contains("perro") || sp.Contains("dog")) return "Guau";
        if (sp.Contains("gato") || sp.Contains("cat")) return "Miau";
        return "Sound";
    }
    public void Register()
    {
        Console.WriteLine($"Registering pet: {Name} with ID: {Id} ");
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Species: {Species}, Breed: {Breed}, Symptom: {Symptom}, Sexo: {Sexo}, ClientId: {ClientId}";
    }
    
    public void SetId(int id)
    {
        Id = id;
    }
}