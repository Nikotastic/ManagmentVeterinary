using ManagmentVeterinary.Data;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Repositories;

public class PetRepository : IPetRepository
{
    public void AddPet(Pet pet)
    {
        pet.Id = Database.NextMascotaId++;
        Database.Pets.Add(pet);
    }
    
    public List<Pet> ListPets()
    {
        return Database.Pets;
    }
    

    public void Update(Pet pet)
    {
        var exist = Database.Pets.FirstOrDefault(x => x.Id == pet.Id);
        if (exist != null)
        {
            exist.Name = pet.Name;
            exist.Species = pet.Species;
            exist.Breed = pet.Breed;
            exist.Age = pet.Age;
            exist.Symptom = pet.Symptom;
            exist.Sexo = pet.Sexo;

        }
    }
    
    public void Delete(int id)
    {
        var exist = Database.Pets.FirstOrDefault(p => p.Id == id);
        if (exist != null)
        {
            Database.Pets.Remove(exist);
        }
    }
    
    public Pet GetById(int id)
    {
        return Database.Pets.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Pet> GetAllByClientId(int clientId)
    {
        return Database.Pets.Where(p => p.ClientId == clientId);
    }
    
}