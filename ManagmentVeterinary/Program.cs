using ManagmentVeterinary.Models;

List<Patient> patients = new List<Patient>();
PatientService service = new PatientService();


string option;

do
{
    Console.WriteLine("\n--- What would you like to do? ---");
    Console.WriteLine(@"1. Register patient
2. List patients
3. Search patient
4. Exit");
    option = Console.ReadLine()!;

    switch (option)
    {
        case "1": service.RegisterPatient(patients); break;
        case "2": service.ListPatients(patients); break;   
        case "3":  service.SearchPatientByName(patients); break;
        case "4":
            Console.WriteLine("Goodbye");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "4");



