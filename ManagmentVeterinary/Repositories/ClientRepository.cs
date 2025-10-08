using Interfaces;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces.Repositories;

public class ClientRepository : IClientRepository
{
    public void AddClient(Client client)
    {
        Data.Database.Clients.Add(client.IdClient, client);
    }

    public List<Client> GetAll()
    {
        return Data.Database.Clients.Values.ToList();
    }

    public Client? GetById(int id)
    {
        Data.Database.Clients.TryGetValue(id, out var client);
        return client;
    }

    public void Update(Client client)
    {
        if (Data.Database.Clients.ContainsKey(client.IdClient))
        {
            Data.Database.Clients[client.IdClient] = client;
        }
    }

    public void Delete(int id)
    {
        Data.Database.Clients.Remove(id);
    }

    public IEnumerable<Client> FindByName(string name)
    {
        return Data.Database.Clients.Values
            .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}

