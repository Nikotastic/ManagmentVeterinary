using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces;
public interface IPatientService
{
    void RegisterPatient(Patient patient);
    List<Patient> GetAllPatients();
    Patient? GetPatientById(int id);
    void UpdatePatient(Patient patient);
    void DeletePatient(int id);
}