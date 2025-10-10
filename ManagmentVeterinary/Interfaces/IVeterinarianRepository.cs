using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces;

// Interface for veterinarian repository
public interface IVeterinarianRepository
{
    void AddVeterinarian(Veterinarian veterinarian);
    Veterinarian GetById(int id);
    List<Veterinarian> GetAll();
    void Update(Veterinarian veterinarian);
    void Delete(int id);
}