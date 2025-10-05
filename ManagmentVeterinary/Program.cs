using ManagmentVeterinary.Models;
using ManagmentVeterinary.Menu; 

// Declaración de la lista de los pacientes 
List<Patient> patients = new List<Patient>();
// Declaración del servicio donde tiene los metodos 
PatientService service = new PatientService();
// Agregando diccionario para conectar paciente y mascota por ID
Dictionary<int, Patient> patientDictionary = new Dictionary<int, Patient>();
// Declaracion del servicio de mascota
PetService petService = new PetService();



string option;

do
{
    Console.WriteLine("\n--- What would you like to do? ---");
    Console.WriteLine(@"1. Register patient
2. List patients
3. Search patient
4. Add pet to patient
5. Delete pet to patient
6. Update pet to patient
7. LINQ Queries (Filters, Sort, Group, etc.)
8. Exit");
    option = Console.ReadLine()!;

    switch (option)
    {
        case "1": service.RegisterPatient(patients, patientDictionary); break;
        case "2": service.ListPatients(patients); break;   
        case "3": service.SearchPatientByName(patients); break;
        case "4": petService.AddPet(patientDictionary); break;
        case "5": petService.RemovePet(patientDictionary); break; 
        case "6": petService.UpdatePet(patientDictionary); break; 
        case "7": MenuLinq.ShowMenuLinq(patients); break;
        case "8":
            Console.WriteLine("Goodbye");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "8");


