using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces.Repositories;

public interface IPatientRepository
{
    void Add(Patient patient);
    void Update(Patient patient);
    void Delete(int id);
    Patient GetById(int id);
    IEnumerable<Patient> GetAll();
    IEnumerable<Patient> FindByName(string name);
}
