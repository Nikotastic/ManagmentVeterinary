using ManagmentVeterinary.Data;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Interfaces.Repositories;


namespace ManagmentVeterinary.Services;

public class ClientService
{
    private static readonly ClientRepository _repo = new ClientRepository();

    public static void RegisterClient()
    {
        Console.Clear();
        Console.WriteLine("\n--- Adding Client ---");

        string name;
        string phone;
        string email;
        string address;

        // --- Nombre ---
        do
        {
            Console.Write("Name: ");
            name = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(name))
                Console.WriteLine("Name cannot be empty.");
        } while (string.IsNullOrEmpty(name));

        // --- Teléfono ---
        do
        {
            Console.Write("Phone: ");
            phone = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("Phone cannot be empty.");
                continue;
            }

            if (!phone.All(char.IsDigit) || phone.Length < 7)
            {
                Console.WriteLine("Invalid phone number. Must contain only digits and at least 7 numbers.");
                phone = ""; // forzar a repetir
            }

        } while (string.IsNullOrEmpty(phone));

        // --- Email ---
        do
        {
            Console.Write("Email: ");
            email = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email cannot be empty.");
                continue;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Console.WriteLine(" Invalid email format. Example: example@mail.com");
                email = ""; // forzar a repetir
            }

        } while (string.IsNullOrEmpty(email));

        // --- Dirección ---
        do
        {
            Console.Write("Address: ");
            address = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(address))
                Console.WriteLine(" Address cannot be empty.");
        } while (string.IsNullOrEmpty(address));

        // --- Registro final ---
        try
        {
            var id = Data.Database.NextClientId++;
            var client = new Client(id, name, phone, email, address);
            _repo.AddClient(client);

            Console.WriteLine($"\n Client added successfully with ID: {client.IdClient}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error while registering client: {e.Message}");
        }
    }

    /*public List<Client> GetAllClients()
    {
        return Data.Database.Clients.Values.ToList();
    }
*/
    public static Client? GetClientById(int id)
    {
        return Data.Database.Clients.TryGetValue(id, out var client) ? client : null;
    }

    public static void UpdateClient()
    {
        Console.Clear();
        Console.WriteLine("\n--- Update client ---");

        Console.Write("Enter client ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID invalid.");
            return;
        }

        var client = GetClientById(id);
        if (client == null)
        {
            Console.WriteLine("\nClient not found.");
            return;
        }

        Console.WriteLine("\n Data client:");
        Console.WriteLine(client);

        Console.WriteLine("\nInser new data (press Enter to keep the current value):");

        Console.Write("\n New name: ");
        string name = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(name))
            client.Name = name;

        Console.Write("\nNew phone: ");
        string phone = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(phone))
            client.Phone = phone;

        Console.Write("\nNew email: ");
        string email = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(email))
            client.Email = email;

        Console.Write("\nNew address: ");
        string address = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(address))
            client.Address = address;

        try
        {
            _repo.Update(client);
            Console.WriteLine($"\n Client updated successfully with ID: {client.IdClient}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n Error to update client: {ex.Message}");
        }
    }

    public static void DeleteClient()
    {
        Console.WriteLine("\n--- Deleting Client ---");
        Console.Write("Insert client ID to delete: ");

        // Validar entrada numérica
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID is invalid. Should be a number.");
            return;
        }

        // Buscar cliente por ID
        var client = GetClientById(id);
        if (client == null)
        {
            Console.WriteLine("\nClient not found.");
            return;
        }

        // Mostrar datos del cliente
        Console.WriteLine("\nData client to delete: ");
        Console.WriteLine(client);

        // Confirmar eliminación
        Console.Write("\nAre you sure? (y/n): ");
        string confirm = Console.ReadLine()!.Trim().ToLower();
        if (confirm != "y")
        {
            Console.WriteLine("\nOperation canceled.");
            return;
        }

        // Eliminar cliente
        _repo.Delete(id);
        Console.WriteLine("\nClient deleted successfully.");
    }



    // Metodo para listar clientes
    public static void ListClients()
    {
        Console.WriteLine("\n--- Listing Clients ---");

        var clients = _repo.GetAll().ToList();

        if (clients.Count == 0)
        {
            Console.WriteLine("No Clients registered yet.");
            return;
        }

        foreach (var c in clients)
        {
            Console.WriteLine($"\n CLIENT ID: {c.IdClient}");
            Console.WriteLine($"   Name: {c.Name}");
            Console.WriteLine($"   Email: {c.Email}");
            Console.WriteLine($"   Phone: {c.Phone}");
            Console.WriteLine($"   Address: {c.Address}");

            // Buscar las mascotas asociadas a este cliente
            var pets = Data.Database.Pets
                .Where(p => p.ClientId == c.IdClient)
                .ToList();

            if (pets.Count == 0)
            {
                Console.WriteLine("   No pets registered for this client.");
            }
            else
            {
                Console.WriteLine("Pets:");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"     - ID: {pet.Id}, Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}");
                }
            }
        }
    }


    // Metodo para buscar cliente por nombre
    public static void SearchClientById()
    {
        Console.WriteLine("\n--- Search Client by ID ---");
        Console.Write("Enter Client ID: ");

        // Validamos que el usuario escriba un número
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            return;
        }

        var client = _repo.GetById(id);

        if (client == null)
        {
            Console.WriteLine($"No client found with ID {id}.");
            return;
        }

        Console.WriteLine("\nClient found:");
        Console.WriteLine($"- ID: {client.IdClient}");
        Console.WriteLine($"- Name: {client.Name}");
        Console.WriteLine($"- Phone: {client.Phone}");
        Console.WriteLine($"- Email: {client.Email}");
        Console.WriteLine($"- Address: {client.Address}");
    }


    public static void AddPetToPatient()
    {
        Console.Write("Enter Client ID: ");
        int clientId = int.Parse(Console.ReadLine() ?? "0");

        if (!Database.Clients.ContainsKey(clientId))
        {
            Console.WriteLine("Client not found.");
            return;
        }

        Console.Write("Pet name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Pet age: ");
        int age = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Species: ");
        string species = Console.ReadLine() ?? "";
        Console.Write("Breed: ");
        string raza = Console.ReadLine() ?? "";
        Console.Write("Sympthom (optional): ");
        string? symptom = Console.ReadLine();
        Console.Write("Sexo: ");
        string sexo = Console.ReadLine() ?? "";


        var pet = new Pet(Database.NextMascotaId++, name, age, species, raza, symptom, clientId, sexo);
        Database.Pets.Add(pet);

        Console.WriteLine("Pet add succesful");
    }
}