using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Repositories;

// Class for the consultation repository, implements the interface IConsultationRepository 
public class ConsultationRepository : IConsultationRepository
{
    // Methods of crud with conect the database
    public void AddConsultation(Consultation consultation)
    {
        Data.Database.Consultations.Add(consultation);
    }
    
    public void Delete(int id)
    {
        var consultation = Data.Database.Consultations.FirstOrDefault(c => c.Id == id);
        if (consultation != null)
            Data.Database.Consultations.Remove(consultation);
        else
            Console.WriteLine($"Consultation with ID {id} not found.");
    }

    public void Update(Consultation consultation)
    {
        var existing = Data.Database.Consultations.FirstOrDefault(c => c.Id == consultation.Id);
        if (existing != null)
        {
            existing.Symptoms = consultation.Symptoms;
            existing.Diagnosis = consultation.Diagnosis;
            existing.Treatment = consultation.Treatment;
            existing.Cost = consultation.Cost;
            existing.Date = consultation.Date;
        }
    }

    public Consultation GetById(int id)
    {
        return Data.Database.Consultations.FirstOrDefault(c => c.Id == id);
    }
    
    public List<Consultation> GetAll()
    {
        return Data.Database.Consultations;
    }
}