using ManagmentVeterinary.Services;

// Inicialización de servicios
PatientService patientService = new PatientService();
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
7. Exit");
    option = Console.ReadLine()!;

    switch (option)
    {
        case "1": patientService.RegisterPatient(); break;
        case "2": patientService.ListPatients(); break;   
        case "3": patientService.SearchPatientByName(); break;
        case "4": petService.AddPet(); break;
        case "5": petService.RemovePet(); break; 
        case "6": petService.UpdatePet(); break; 
        case "7":
            Console.WriteLine("Goodbye");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "7");
