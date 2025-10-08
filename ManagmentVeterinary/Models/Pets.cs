using ManagmentVeterinary.Interfaces;

namespace ManagmentVeterinary.Models;

public class Pet: Animal, INotificable, IRegistrable
{
    public int Id { get; set; }
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
        Console.WriteLine($"[Notificación a dueño {Name}]: {message}");
    }

    public override string IssueSound()
    {
        if (Species.ToLower().Contains("perro")) return "Guau";
        if (Species.ToLower().Contains("gato")) return "Miau";
        return "Sonido";
    }
    public void Register()
    {
        Console.WriteLine($"Registering pet: {Name} with ID: {Id} ");
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Species: {Species}, Breed: {Breed}, Symptom: {Symptom}, Sexo: {Sexo}, ClientId: {ClientId}";
    }
}