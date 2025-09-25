namespace ManagmentVeterinary.Models;

public class PatientService
{
    // Metodo para registar paciente
    public void RegisterPatient(List<Patient> patients)
    {
        Console.WriteLine("\n--- Adding patient ---");
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine()!);
        Console.Write("Symptom: ");
        string symptom = Console.ReadLine()!;

        Patient data = new Patient(name, age, symptom);
        patients.Add(data);
        
        Console.WriteLine("Patient added");
    }

    // Metodo para listar pacientes
    public void ListPatients(List<Patient> patients)
    {
        Console.WriteLine("\n--- Listing patients ---");
        if (patients.Count == 0) 
        {
            Console.WriteLine("No patients registered yet.");
            return;
        }
        foreach (var p in patients)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}, Symptom: {p.Symptom}");
        }
    }
    // Metodo para buscar paciente por nombre
    public void SearchPatientByName(List<Patient> patients)
    {
        Console.WriteLine("\n--- Search Patient ---");
        Console.Write("Enter patient name: ");
        string name = Console.ReadLine() ?? "";
        // Busca el paciente por nombre
        var results = patients
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("️No patient found with that name.");
            return;
        }

        Console.WriteLine($"Found {results.Count} patient(s):");
        foreach (var patient in results)
        {
            Console.WriteLine($"- Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
        }
    }
}