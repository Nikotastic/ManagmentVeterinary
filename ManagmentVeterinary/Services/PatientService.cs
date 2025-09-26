namespace ManagmentVeterinary.Models;

public class PatientService
{
    // Metodo para registar paciente
    public void RegisterPatient(List<Patient> patients, Dictionary<int, Patient> patientDictionary)
    {
        Console.WriteLine("\n--- Adding patient ---");
        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        // Inicializamos la edad y validacion
        int age = 0;
        bool ageValided = false; // Validacion de la edad 

        while (!ageValided)
        {
            Console.Write("Age: ");
            string ageInput = Console.ReadLine()!;
            try 
            {
                age = int.Parse(ageInput);
                ageValided = true; // ya fue validada
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }
        }
        
        Console.Write("Phone: ");
        string phone = Console.ReadLine()!;

        Patient data = new Patient(name, age, phone);
        patients.Add(data);
        patientDictionary.Add(data.PatientId, data); // Agregamos el paciente al diccionario
        
        Console.WriteLine($"Patient added successfully with ID: {data.PatientId}");
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
        // Mostramos los pacientes
        foreach (var p in patients)
        {
            Console.WriteLine($"- ID {p.PatientId}, Name: {p.Name}, Age: {p.Age}, Symptom: {p.Phone}");

            // Mostramos las mascotas del paciente
            if (p.Pets.Count > 0)
            {
                Console.WriteLine("Pets:");
                foreach (var pet in p.Pets)
                {
                    Console.WriteLine($"- Name: {pet.Name}, Species: {pet.Species}, Age:{pet.Age}, Symptom: {pet.Symptom}");
                }
            }
            else
            {
                Console.WriteLine("No pets registered for this patient.");
            }
        }
        
    }
    // Metodo para buscar paciente por nombre
    public void SearchPatientByName(List<Patient> patients)
    {
        Console.WriteLine("\n--- Search Patient ---");
        Console.Write("Enter patient name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Please enter a valid name.");
            return;
        }
        
        // Busca el paciente por nombre
        var results = patients
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
        // Mostramos los resultados
        Console.WriteLine($"Found {results.Count} patient(s):");
        if (results.Count == 0)
        {
            Console.WriteLine("️No patient found with that name.");
            return;
        }
        foreach (var patient in results)
        {
            Console.WriteLine($"- Name: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}");
        }
    }

}