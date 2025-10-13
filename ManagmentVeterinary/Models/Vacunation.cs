namespace ManagmentVeterinary.Models;

// class for the vaccination and implements the interface IAttentive
public class Vacunation : VeterinaryService
{
    public string TypeOfVaccine{ get; set; }
    public DateTime NextDoseDate { get; set; }

    public Vacunation(int id, string description, decimal cost, string typeOfVaccine, DateTime nextDoseDate) 
        : base(id, description, cost)
    {
        TypeOfVaccine = typeOfVaccine;
        NextDoseDate = nextDoseDate;
    }

    public override void Attend(Pet pet)
    {
        Console.WriteLine($"Applying vaccine {TypeOfVaccine} to {pet.Name}");
        Console.WriteLine($"Next dose scheduled for: {NextDoseDate :dd/MM/yyyy}");
        pet.SendNotification($"Vaccine {TypeOfVaccine} applied. Next dose: {NextDoseDate :dd/MM/yyyy}");
        
        // The pet makes a sound during vaccination
        Console.WriteLine($"The pet says: {pet.IssueSound()}");
    }
}
