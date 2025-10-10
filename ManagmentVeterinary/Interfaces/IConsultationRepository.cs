using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces;

public interface IConsultationRepository
{
    void AddConsultation (Consultation consultation);
    void Delete(int id);
    void Update(Consultation consultation);
    Consultation GetById(int id);
    List<Consultation> GetAll();
}