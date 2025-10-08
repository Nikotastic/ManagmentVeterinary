using ManagmentVeterinary.Models;
using ManagmentVeterinary.Services;
namespace ManagmentVeterinary.Interfaces;

public interface IClientRepository
{
    void AddClient(Client client);
    List<Client> GetAll();
    Client? GetById(int id);
    void Update(Client client);
    void Delete(int id);
    IEnumerable<Client> FindByName(string name);
}