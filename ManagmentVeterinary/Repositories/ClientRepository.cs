using Interfaces;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces.Repositories;

public interface IClientRepository : IRepository<Client>
{
    void RegisterClient(Client client);
    IEnumerable<Client> FindByName(string name);
    Client? GetClientById(int id);
    void UpdateClient(Client client);
    void DeleteClient(int id);
    
}
