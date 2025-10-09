using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Interfaces;

public interface IVeterinarianRepository
{
    void AddVeterinarian(Veterinarian veterinarian);
    Veterinarian GetById(int id);
    List<Veterinarian> GetAll();
    void Update(Veterinarian veterinarian);
    void Delete(int id);
}