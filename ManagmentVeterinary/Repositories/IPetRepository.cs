using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces.Repositories;

public interface IPetRepository
{
    void Add(int patientId, Pet pet);
    void Update(int patientId, Pet pet);
    void Delete(int patientId, string petName);
    Pet GetByName(int patientId, string name);
    IEnumerable<Pet> GetAllByPatientId(int patientId);
}
