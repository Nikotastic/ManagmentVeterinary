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

    // Metodo para agregar mascota a paciente
    public void AddPet(Dictionary<int, Patient> patientDictionary)
    {
        Console.WriteLine("\n--- Add Pet ---");
        Console.Write("Enter patient ID: ");
        string patientIdInput = Console.ReadLine()!;
        int patientId = int.Parse(patientIdInput);

        if (!patientDictionary.ContainsKey(patientId))
        {
            Console.WriteLine("Patient not found.");
            return;
        }
        Console.Write("Enter pet name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter pet species: ");
        string species = Console.ReadLine()!;
        Console.Write("Enter pet age: ");
        string ageInput = Console.ReadLine()!;
        int age = int.Parse(ageInput);
        Console.Write("Symptom: ");
        string symptom = Console.ReadLine()!;

        // Creamos la mascota y la agregamos al paciente
        Pet pet = new Pet(name, species, age, symptom);
        patientDictionary[patientId].Pets.Add(pet);
        
        Console.WriteLine($"Pet added successfully");
    }

    // Metodo para eliminar mascota de paciente
    public void RemovePet(Dictionary<int, Patient> patientDictionary)
    {
        Console.WriteLine("\n--- Delete Pet ---");
        Console.Write("Enter patient ID: ");
        string patientIdInput = Console.ReadLine()!;
        int patientId = int.Parse(patientIdInput);
        // Validacion del paciente

        if (!patientDictionary.ContainsKey(patientId))
        {
            Console.WriteLine("Patient not found.");
            return;
        }
        Console.Write("Enter pet name: ");
        string name = Console.ReadLine()!;
        // Validacion de la mascota
        // Buscamos el ID del paciente y luego accedemos a la lista de mascotas y verifica si existe 
        if (patientDictionary[patientId].Pets.Any(p => p.Name == name))
        {
            // Removemos la primera mascota de la lista de mascotas del paciente 
            patientDictionary[patientId].Pets.Remove(patientDictionary[patientId].Pets.First(p => p.Name == name));
            Console.WriteLine($"Pet {name} deleted successfully");
        }
        else
        {
            Console.WriteLine($"Pet {name} not found for patient {patientId}");
        }
    }

    public void UpdatePet(Dictionary<int, Patient> patientDictionary)
    {
        Console.WriteLine("\n--- Update Pet ---");
        Console.Write("Enter patient ID: ");
        string patientIdInput = Console.ReadLine()!;
    
        // Validamos que el ID del paciente exista y que sea un numero
        if (!int.TryParse(patientIdInput, out int patientId) || !patientDictionary.ContainsKey(patientId))
        {
            Console.WriteLine("Patient not found");
            return;
        }

        Console.Write("Enter pet name: ");
        string name = Console.ReadLine()!;

        // Buscar la mascota
        var pet = patientDictionary[patientId].Pets.FirstOrDefault(p => p.Name == name);

        if (pet == null)
        {
            Console.WriteLine($"Pet {name} not found for patient {patientId}");
            return;
        }

        // Si la mascota existe, pedimos nuevos datos
        Console.Write("Enter new pet name: ");
        string newName = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newName))
            pet.Name = newName;

        Console.Write("Enter new species: ");
        string newSpecies = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newSpecies))
            pet.Species = newSpecies;

        Console.Write("Enter new age: ");
        string newAgeInput = Console.ReadLine()!;
        if (int.TryParse(newAgeInput, out int newAge))
            pet.Age = newAge;
        
        Console.Write("Enter new symptom: ");
        string newSymptom = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(newSymptom))
            pet.Symptom = newSymptom;

        Console.WriteLine($"Pet updated successfully");
    }

}