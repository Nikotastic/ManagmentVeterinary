using ManagmentVeterinary.Data;
using ManagmentVeterinary.Models;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Menu;
using ManagmentVeterinary.Repositories;


namespace ManagmentVeterinary.Services;

public class ClientService
{
    private static readonly ClientRepository _repo = new ClientRepository();
    private static readonly PetRepository _petRepository = new PetRepository();

    public static void RegisterClient()
    {
        Console.Clear();
        Console.WriteLine("\n--- Adding Client ---");

        // Nombre
        var name = BreakBucle.GetStringOrCancel("Name");
        if (name == null) return;

        // Teléfono
        string? phone;
        do
        {
            phone = BreakBucle.GetStringOrCancel("Phone");
            if (phone == null) return;

            if (!phone.All(char.IsDigit) || phone.Length < 7)
            {
                Console.WriteLine("Invalid phone number. Must contain only digits and at least 7 numbers.");
                phone = null;
            }
        } while (phone == null);

        // Email
        string? email;
        do
        {
            email = BreakBucle.GetStringOrCancel("Email");
            if (email == null) return;

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Console.WriteLine("Invalid email format. Example: example@mail.com");
                email = null;
            }
        } while (email == null);

        // Dirección
        var address = BreakBucle.GetStringOrCancel("Address");
        if (address == null) return;

        // Registro final
        try
        {
            var id = Database.NextClientId++;
            var client = new Client(id, name, phone, email, address);
            _repo.AddClient(client);

            Console.WriteLine($"\nClient added successfully with ID: {client.IdClient}");
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

        var idInput = BreakBucle.GetStringOrCancel("Enter client ID");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("\nID invalid. It must be a number");
            return;
        }

        var client = GetClientById(id);
        if (client == null)
        {
            Console.WriteLine("\nClient not found.");
            return;
        }

        Console.WriteLine("\nData client:");
        Console.WriteLine(client);

        Console.WriteLine("\nInsert new data (or 'cancel' to exit, press Enter to keep the current value):");

        var newName = BreakBucle.GetStringOrCancel("New name", true);
        if (newName == null) return;
        if (!string.IsNullOrWhiteSpace(newName))
            client.Name = newName;

        var newPhone = BreakBucle.GetStringOrCancel("New phone", true);
        if (newPhone == null) return;
        if (!string.IsNullOrWhiteSpace(newPhone))
            client.Phone = newPhone;

        var newEmail = BreakBucle.GetStringOrCancel("New email", true);
        if (newEmail == null) return;
        if (!string.IsNullOrWhiteSpace(newEmail))
            client.Email = newEmail;

        var newAddress = BreakBucle.GetStringOrCancel("New address", true);
        if (newAddress == null) return;
        if (!string.IsNullOrWhiteSpace(newAddress))
            client.Address = newAddress;

        try
        {
            _repo.Update(client);
            Console.WriteLine($"\nClient updated successfully with ID: {client.IdClient}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError updating client: {ex.Message}");
        }
    }

    public static void DeleteClient()
    {
        Console.WriteLine("\n--- Deleting Client ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Insert client ID to delete");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("\nID is invalid. Should be a number.");
            return;
        }

        var client = GetClientById(id);
        if (client == null)
        {
            Console.WriteLine("\nClient not found.");
            return;
        }

        Console.WriteLine("\nData client to delete: ");
        Console.WriteLine(client);

        var confirm = BreakBucle.GetStringOrCancel("Are you sure? (y/n)");
        if (confirm == null || confirm.ToLower() != "y")
        {
            Console.WriteLine("\nOperation canceled.");
            return;
        }

        _repo.Delete(id);
        _petRepository.DeleteAllByClientId(id);
        Console.WriteLine("\nClient and pets successfully removed");
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
            Console.WriteLine($"\n - CLIENT ID: {c.IdClient}");
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
                Console.WriteLine(" - No pets registered for this client");
            }
            else
            {
                Console.WriteLine("Pets:");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"    - ID: {pet.Id}, Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}");
                }
            }
        }
    }


    // Metodo para buscar cliente por nombre
    public static void SearchClientById()
    {
        Console.WriteLine("\n--- Search Client by ID ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Enter Client ID");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int id))
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
        Console.WriteLine("\n--- Adding Pet to Patient ---");
        
        var idInput = BreakBucle.GetStringOrCancel("Enter Client ID");
        if (idInput == null) return;

        if (!int.TryParse(idInput, out int clientId))
        {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            return;
        }

        if (!Database.Clients.ContainsKey(clientId))
        {
            Console.WriteLine("Client not found.");
            return;
        }

        var name = BreakBucle.GetStringOrCancel("Enter pet name");
        if (name == null) return;

        var species = BreakBucle.GetStringOrCancel("Enter species");
        if (species == null) return;

        var breed = BreakBucle.GetStringOrCancel("Enter breed");
        if (breed == null) return;

        var ageInput = BreakBucle.GetStringOrCancel("Enter age");
        if (ageInput == null) return;

        if (!int.TryParse(ageInput, out int age) || age <= 0)
        {
            Console.WriteLine("Invalid age. Must be a positive number.");
            return;
        }

        var symptom = BreakBucle.GetStringOrCancel("Enter symptoms (optional)", true);
        if (symptom == null) return;

        string? sex;
        do
        {
            sex = BreakBucle.GetStringOrCancel("Enter sex (M/F)");
            if (sex == null) return;
            
            sex = sex.ToUpper();
            if (sex != "M" && sex != "F")
            {
                Console.WriteLine("Invalid sex. Must be 'M' or 'F'.");
                sex = null;
            }
        } while (sex == null);

        var pet = new Pet(Database.NextMascotaId++, name, age, species, breed, symptom, clientId, sex);
        _petRepository.AddPet(pet);     

        Console.WriteLine("\nPet added successfully!");
    }
}