using ManagmentVeterinary.Models;

// Declaración de la lista de los pacientes 
List<Patient> patients = new List<Patient>();
// Declaración del servicio donde tiene los metodos 
PatientService service = new PatientService();
// Declaracion de lista de los perros
List<Pet> Pets  = new List<Pet>();
// Agregando diccionario para conectar paciente y mascota por ID
Dictionary<int, Patient> patientDictionary = new Dictionary<int, Patient>();



string option;

do
{
    Console.WriteLine("\n--- What would you like to do? ---");
    Console.WriteLine(@"1. Register patient
2. List patients
3. Search patient
4. Add pet to patient
5. Exit");
    option = Console.ReadLine()!;

    switch (option)
    {
        case "1": service.RegisterPatient(patients, patientDictionary); break;
        case "2": service.ListPatients(patients); break;   
        case "3":  service.SearchPatientByName(patients); break;
        case "4":  service.AddPet(patientDictionary); break;
        case "5":
            Console.WriteLine("Goodbye");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "5");


