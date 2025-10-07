using ManagmentVeterinary.Data;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Repositories;

public class PetRepository : IPetRepository
{
    private readonly Database _db;

    public PetRepository()
    {
        _db = Database.Instance;
    }

    public void Add(int patientId, Pet pet)
    {
        if (_db.Patients.TryGetValue(patientId, out var patient))
        {
            patient.Pets.Add(pet);
        }
    }

    public void Update(int patientId, Pet pet)
    {
        if (_db.Patients.TryGetValue(patientId, out var patient))
        {
            var existingPet = patient.Pets.FirstOrDefault(p => p.Name == pet.Name);
            if (existingPet != null)
            {
                var index = patient.Pets.IndexOf(existingPet);
                patient.Pets[index] = pet;
            }
        }
    }

    public void Delete(int patientId, string petName)
    {
        if (_db.Patients.TryGetValue(patientId, out var patient))
        {
            var pet = patient.Pets.FirstOrDefault(p => p.Name == petName);
            if (pet != null)
            {
                patient.Pets.Remove(pet);
            }
        }
    }

    public Pet? GetByName(int patientId, string name)
    {
        return _db.Patients.TryGetValue(patientId, out var patient)
            ? patient.Pets.FirstOrDefault(p => p.Name == name)
            : null;
    }

    public IEnumerable<Pet> GetAllByPatientId(int patientId)
    {
        return _db.Patients.TryGetValue(patientId, out var patient)
            ? patient.Pets
            : Enumerable.Empty<Pet>();
    }
}
