using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Services;

namespace ManagmentVeterinary.Menu;
public class MenuPatient
{
    // Servicio que maneja la lógica de negocio de pacientes
    private readonly ClientService _clientService;

    // Constructor que inicializa el servicio de pacientes
    public MenuPatient()
    {
        _clientService = new ClientService();
    }
    
    // Muestra el menú principal de gestión de pacientes y maneja la interacción del usuario
    
    public void ShowMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("\n=== MENÚ DE GESTIÓN DE PACIENTES ===");
            Console.WriteLine("1. Registrar nuevo paciente");
            Console.WriteLine("2. Ver lista de pacientes");
            Console.WriteLine("3. Buscar paciente por ID");
            Console.WriteLine("4. Actualizar información de paciente");
            Console.WriteLine("5. Eliminar paciente");
            Console.WriteLine("6. Agregar mascota a paciente");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("\nSeleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterClient();
                    break;
                case "2":
                    ListClient();
                    break;
                case "3":
                    SearchClient();
                    break;
                case "4":
                    UpdateClient();
                    break;
                case "5":
                    DeleteClient();
                    break;
                case "6":
                    AddPetToPatient();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    //Registra un nuevo paciente solicitando los datos necesarios al usuario
    private void RegisterClient()
    {
        Console.WriteLine("\n--- Adding Client ---");
        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Phone: ");
        string phone = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Address: ");
        string address = Console.ReadLine()!;
        
        if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
        {
            Console.WriteLine("Invalid client data");
            return;
        }

        int newId = GetAllClients().Any() ? GetAllClients().Max(c => c.IdClient) + 1 : 1;

        var client = new Client(newId, name, phone, email, address);
        _repo.Add(client);

        Console.WriteLine($"Client added successfully with ID: {client.IdClient}");
    }

   
    // Muestra la lista completa de pacientes registrados
    private void ListClient()
    {
        Console.Clear();
        Console.WriteLine("\n=== LISTA DE PACIENTES ===\n");

        var patients = _clientService.GetAllClients();

        if (!patients.Any())
        {
            Console.WriteLine("No hay pacientes registrados.");
        }
        else
        {
            foreach (var patient in patients)
            {
                DisplayPatientInfo(patient);
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

  
    // Busca y muestra la información de un paciente por su ID
   
    private void SearchClient()
    {
        Console.Clear();
        Console.WriteLine("\n=== BUSCAR PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _clientService.GetClientById(id);
            if (patient != null)
            {
                DisplayPatientInfo(patient);
            }
            else
            {
                Console.WriteLine("\nPaciente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\nID inválido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    
    // Actualiza la información de un paciente existente
    private void UpdateClient()
    {
        Console.Clear();
        Console.WriteLine("\n=== ACTUALIZAR PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente a actualizar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _clientService.GetClientById(id);
            if (patient != null)
            {
                Console.WriteLine("\nDatos actuales del paciente:");
                DisplayPatientInfo(patient);

                Console.WriteLine("\nIngrese los nuevos datos (presione Enter para mantener el valor actual):");

                Console.Write("\nNombre: ");
                string? newName = Console.ReadLine();
                patient.Name = string.IsNullOrWhiteSpace(newName) ? patient.Name : newName;

                /*Console.Write("Edad: ");
                string? newAgeStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAgeStr) && int.TryParse(newAgeStr, out int newAge))
                {
                    patient.Age = newAge;
                }*/

                Console.Write("Teléfono: ");
                string? newPhone = Console.ReadLine();
                patient.Phone = string.IsNullOrWhiteSpace(newPhone) ? patient.Phone : newPhone;

                _clientService.UpdateClient(patient);
                Console.WriteLine("\n¡Paciente actualizado exitosamente!");
            }
            else
            {
                Console.WriteLine("\nPaciente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\nID inválido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Elimina un paciente del sistema
    /// </summary>
    private void DeleteClient()
    {
        Console.Clear();
        Console.WriteLine("\n=== ELIMINAR PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _clientService.GetClientById(id);
            if (patient != null)
            {
                Console.WriteLine("\nDatos del paciente a eliminar:");
                DisplayPatientInfo(patient);

                Console.Write("\n¿Está seguro que desea eliminar este paciente? (S/N): ");
                if (Console.ReadLine()?.Trim().ToUpper() == "S")
                {
                    _clientService.DeleteClient(id);
                    Console.WriteLine("\n¡Paciente eliminado exitosamente!");
                }
                else
                {
                    Console.WriteLine("\nOperación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("\nPaciente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\nID inválido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Agrega una mascota a un paciente existente
    /// </summary>
    private void AddPetToPatient()
    {
        Console.Clear();
        Console.WriteLine("\n=== AGREGAR MASCOTA A PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _clientService.GetClientById(id);
            if (patient != null)
            {
                // Aquí iría la lógica para crear y agregar una mascota
                Console.WriteLine("\nFuncionalidad en desarrollo...");
            }
            else
            {
                Console.WriteLine("\nPaciente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\nID inválido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Muestra la información detallada de un paciente
    /// </summary>
    /// <param name="client">Paciente del cual mostrar la información</param>
    private void DisplayPatientInfo(Client client)
    {
        Console.WriteLine($"ID: {client.IdClient}");
        Console.WriteLine($"Nombre: {client.Name}");
        //Console.WriteLine($"Edad: {client.Age}");
        Console.WriteLine($"Teléfono: {client.Phone}");
        Console.WriteLine($"Email: {client.Email}");
        Console.WriteLine($"Dirección: {client.Address}");
        Console.WriteLine("----------------------------------------");
    }
}