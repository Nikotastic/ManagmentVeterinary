namespace ManagmentVeterinary.Models;

public class PatientService
{
    public required List <Patient> Pacients { get; set; }
    
    public void RegisterPatient()
    {
        Console.WriteLine("Adding patient");
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine()!);
        Console.Write("Symptom: ");
        string symptom = Console.ReadLine()!;

        Patient Data = new Patient(name, age, symptom);
        Pacients.Add(Data);
    }
}