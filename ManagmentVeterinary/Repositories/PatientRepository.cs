using ManagmentVeterinary.Data;
using ManagmentVeterinary.Interfaces.Repositories;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly Database _db;

    public PatientRepository()
    {
        _db = Database.Instance;
    }

    public void Add(Patient patient)
    {
        _db.Patients.Add(patient.PatientId, patient);
    }

    public void Update(Patient patient)
    {
        if (_db.Patients.ContainsKey(patient.PatientId))
        {
            _db.Patients[patient.PatientId] = patient;
        }
    }

    public void Delete(int id)
    {
        if (_db.Patients.ContainsKey(id))
        {
            _db.Patients.Remove(id);
        }
    }

    public Patient GetById(int id)
    {
        return _db.Patients.TryGetValue(id, out var patient) ? patient : null;
    }

    public IEnumerable<Patient> GetAll()
    {
        return _db.Patients.Values;
    }

    public IEnumerable<Patient> FindByName(string name)
    {
        return _db.Patients.Values
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}
