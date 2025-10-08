using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Models;
namespace ManagmentVeterinary.Models;

public class Veterinarian : Person, INotificable, IRegistrable
{
    public int VeterinarianId { get; set; }
    public string Specialization { get; set; }

    public Veterinarian(int id, string name, string phone, string? email, string specialization) : base(name, phone,
        email)
    {
        VeterinarianId = id;
        Specialization = specialization;
    }

    public void SendNotification(string messege)
    {
        Console.WriteLine($"Sending notification to {Name} about {messege} on {(DateTime.Now.ToShortDateString())}");
    }
    
    public void Register()
    {
        Console.WriteLine($"Registering veterinarian: {Name} with ID: {VeterinarianId} ");
    }
    
    public override string ToString()
    {
        return $"Id: {VeterinarianId}, Name: {Name}, Phone: {Phone}, Email: {Email}, Specialization: {Specialization}";
    }
    
}