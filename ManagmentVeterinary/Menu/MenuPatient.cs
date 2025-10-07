using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Services;

namespace ManagmentVeterinary.Menu;
public class MenuPatient
{
    // Servicio que maneja la lógica de negocio de pacientes
    private readonly IPatientService _patientService;

    // Constructor que inicializa el servicio de pacientes
    public MenuPatient()
    {
        _patientService = new PatientService();
    }

    /// <summary>
    /// Muestra el menú principal de gestión de pacientes y maneja la interacción del usuario
    /// </summary>
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
                    RegisterPatient();
                    break;
                case "2":
                    ListPatients();
                    break;
                case "3":
                    SearchPatient();
                    break;
                case "4":
                    UpdatePatient();
                    break;
                case "5":
                    DeletePatient();
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

    /// <summary>
    /// Registra un nuevo paciente solicitando los datos necesarios al usuario
    /// </summary>
    private void RegisterPatient()
    {
        Console.Clear();
        Console.WriteLine("\n=== REGISTRO DE NUEVO PACIENTE ===");

        Console.Write("Nombre: ");
        string? name = Console.ReadLine();

        int age;
        do
        {
            Console.Write("Edad: ");
        } while (!int.TryParse(Console.ReadLine(), out age) || age < 0);

        Console.Write("Teléfono: ");
        string? phone = Console.ReadLine();

        try
        {
            var patient = new Patient(name, age, phone);
            _patientService.RegisterPatient(patient);
            Console.WriteLine("\n¡Paciente registrado exitosamente!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al registrar paciente: {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Muestra la lista completa de pacientes registrados
    /// </summary>
    private void ListPatients()
    {
        Console.Clear();
        Console.WriteLine("\n=== LISTA DE PACIENTES ===\n");

        var patients = _patientService.GetAllPatients();

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

    /// <summary>
    /// Busca y muestra la información de un paciente por su ID
    /// </summary>
    private void SearchPatient()
    {
        Console.Clear();
        Console.WriteLine("\n=== BUSCAR PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _patientService.GetPatientById(id);
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

    /// <summary>
    /// Actualiza la información de un paciente existente
    /// </summary>
    private void UpdatePatient()
    {
        Console.Clear();
        Console.WriteLine("\n=== ACTUALIZAR PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente a actualizar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _patientService.GetPatientById(id);
            if (patient != null)
            {
                Console.WriteLine("\nDatos actuales del paciente:");
                DisplayPatientInfo(patient);

                Console.WriteLine("\nIngrese los nuevos datos (presione Enter para mantener el valor actual):");

                Console.Write("\nNombre: ");
                string? newName = Console.ReadLine();
                patient.Name = string.IsNullOrWhiteSpace(newName) ? patient.Name : newName;

                Console.Write("Edad: ");
                string? newAgeStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAgeStr) && int.TryParse(newAgeStr, out int newAge))
                {
                    patient.Age = newAge;
                }

                Console.Write("Teléfono: ");
                string? newPhone = Console.ReadLine();
                patient.Phone = string.IsNullOrWhiteSpace(newPhone) ? patient.Phone : newPhone;

                _patientService.UpdatePatient(patient);
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
    private void DeletePatient()
    {
        Console.Clear();
        Console.WriteLine("\n=== ELIMINAR PACIENTE ===\n");

        Console.Write("Ingrese el ID del paciente a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var patient = _patientService.GetPatientById(id);
            if (patient != null)
            {
                Console.WriteLine("\nDatos del paciente a eliminar:");
                DisplayPatientInfo(patient);

                Console.Write("\n¿Está seguro que desea eliminar este paciente? (S/N): ");
                if (Console.ReadLine()?.Trim().ToUpper() == "S")
                {
                    _patientService.DeletePatient(id);
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
            var patient = _patientService.GetPatientById(id);
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
    /// <param name="patient">Paciente del cual mostrar la información</param>
    private void DisplayPatientInfo(Patient patient)
    {
        Console.WriteLine($"ID: {patient.PatientId}");
        Console.WriteLine($"Nombre: {patient.Name}");
        Console.WriteLine($"Edad: {patient.Age}");
        Console.WriteLine($"Teléfono: {patient.Phone}");
        Console.WriteLine($"Cantidad de mascotas: {patient.Pets.Count}");
        Console.WriteLine("----------------------------------------");
    }
}