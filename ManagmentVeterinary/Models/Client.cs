using ManagmentVeterinary.Interfaces;
namespace ManagmentVeterinary.Models;

// class for the client and implements the interfaces INotification and IRegistrable
public class Client: Person, INotification, IRegistrable
{
    public int IdClient { get; private set; }
    public string Address { get; set; }
    
    public Client(int idClient, string name, string phone, string? email, string address) : base( name, phone, email)
    {
        IdClient = idClient;
        Address = address;
    }
    
    // Implementing the interface methods
    public void SendNotification(string message)
    {
        Console.WriteLine($"[Notificación a dueño {Name}]: {message}");
    }
    
    public void Register()
    {
        Console.WriteLine($"Registering client: {Name} with ID: {IdClient} ");
    }
    
    public override string ToString()
    {
        return $"Id: {IdClient}, Name: {Name}, Phone: {Phone}, Email: {Email}, Address: {Address}";
    }
    
}


