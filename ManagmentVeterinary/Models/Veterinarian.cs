using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Models;
namespace ManagmentVeterinary.Models;

public class Veterinarian : Person, INotificable
{
    public int VeterinarianId { get; set; }
    public string Specialization { get; set; }
    
    public Veterinarian(int id, string name, string phone, string? email, string specialization) : base(id, name, phone, email)
    {
        VeterinarianId = id;
        Specialization = specialization;
    }
    
    public void SendNotification(Pet pet)
    {
        Console.WriteLine($"Sending notification to {pet.Owner?.Name} about {pet.Name} on {(DateTime.Now.ToShortDateString())}");
    }
    
    
}