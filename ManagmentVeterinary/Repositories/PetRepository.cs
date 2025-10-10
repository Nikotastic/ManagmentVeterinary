using ManagmentVeterinary.Data;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Repositories;

public class PetRepository : IPetRepository
{
    // Methods of crud with conect the database
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
        Database.Pets.RemoveAll(p => p.Id == id); 
    }
    
    public Pet GetById(int id)
    {
        return Database.Pets.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Pet> GetAllByClientId(int clientId)
    {
        return Database.Pets.Where(p => p.ClientId == clientId);
    }
    
    // remove multiple pets by ClientId
    public void DeleteAllByClientId(int clientId)
    {
        Database.Pets.RemoveAll(pet => pet.ClientId == clientId);
    }
    
    
}