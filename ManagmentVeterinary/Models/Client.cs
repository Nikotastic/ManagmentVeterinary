using ManagmentVeterinary.Interfaces;
namespace ManagmentVeterinary.Models;

public class Client: Person, INotificable, IRegistrable
{
    public int IdClient { get; set; }
    public string Address { get; set; }
    
    public Client(int idClient, string name, string phone, string? email, string address) : base( name, phone, email)
    {
        IdClient = idClient;
        Address = address;
    }
    
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


