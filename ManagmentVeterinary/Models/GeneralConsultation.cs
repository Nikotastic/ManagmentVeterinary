namespace ManagmentVeterinary.Models;

public class GeneralConsultation : VeterinaryService
{
    public string Diagnosis { get; set; }

    public GeneralConsultation(int id, string description, decimal cost, string diagnosis) 
        : base(id, description, cost)
    {
        Diagnosis = diagnosis;
    }

    public override void Attend(Pet pet)
    {
        Console.WriteLine($"Making a general inquiry to {pet.Name}");
        Console.WriteLine($"Symptoms presented: {pet.Symptom ?? "Ninguno"}");
        Console.WriteLine($"Diagnosis: {Diagnosis}");
        pet.SendNotification($"General consultation carried out. Diagnosis: {Diagnosis}");
        
        // La mascota emite un sonido durante la consulta
        Console.WriteLine($"The pet says: {pet.IssueSound()}");
    }
}
