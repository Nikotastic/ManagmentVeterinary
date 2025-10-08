using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces.Repositories;

public interface IPetRepository
{
    void AddPet(Pet pet);
    void Update(Pet pet);
    void Delete(int id);
    Pet? GetById(int id);
    IEnumerable<Pet> GetAllByClientId(int clientId);
}

