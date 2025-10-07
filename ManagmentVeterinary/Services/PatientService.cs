using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Repositories;

namespace ManagmentVeterinary.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService()
    {
        _patientRepository = new PatientRepository();
    }

    public void RegisterPatient(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        _patientRepository.Add(patient);
    }

    public List<Patient> GetAllPatients()
    {
        return _patientRepository.GetAll().ToList();
    }

    public Patient? GetPatientById(int id)
    {
        return _patientRepository.GetAll().FirstOrDefault(p => p.PatientId == id);
    }

    public void UpdatePatient(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        var existingPatient = GetPatientById(patient.PatientId);
        if (existingPatient == null)
            throw new InvalidOperationException("Paciente no encontrado");

        // Aquí iría la lógica de actualización en el repositorio
        // Por ahora solo actualizamos en memoria ya que el repositorio no tiene método de actualización
        existingPatient.Name = patient.Name;
        existingPatient.Age = patient.Age;
        existingPatient.Phone = patient.Phone;
    }

    public void DeletePatient(int id)
    {
        var patient = GetPatientById(id);
        if (patient == null)
            throw new InvalidOperationException("Paciente no encontrado");

        // Aquí iría la lógica de eliminación en el repositorio
        // Por ahora solo eliminamos de la lista en memoria
        _patientRepository.Delete(id);
    }

    // Metodo para registar paciente
    public void RegisterPatient()
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
            if (int.TryParse(Console.ReadLine(), out age))
            {
                ageValided = true; // ya fue validada
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }
        }

        Console.Write("Phone: ");
        string phone = Console.ReadLine()!;

        var patient = new Patient(name, age, phone);
        _patientRepository.Add(patient);

        Console.WriteLine($"Patient added successfully with ID: {patient.PatientId}");
    }

    // Metodo para listar pacientes
    public void ListPatients()
    {
        Console.WriteLine("\n--- Listing patients ---");
        var patients = _patientRepository.GetAll().ToList();

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
    public void SearchPatientByName()
    {
        Console.WriteLine("\n--- Search Patient ---");
        Console.Write("Enter patient name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Please enter a valid name.");
            return;
        }

        var patients = _patientRepository.FindByName(name).ToList();

        // Mostramos los resultados
        Console.WriteLine($"Found {patients.Count} patient(s):");
        if (patients.Count == 0)
        {
            Console.WriteLine("No patient found with that name.");
            return;
        }

        foreach (var patient in patients)
        {
            Console.WriteLine($"- Name: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}");
        }
    }

}