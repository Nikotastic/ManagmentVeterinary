using ManagmentVeterinary.Interfaces;
using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Repositories;

public class VeterinarianRepository : IVeterinarianRepository
{
    public void AddVeterinarian(Veterinarian veterinarian)
    {
        Data.Database.Veterinaries.Add(veterinarian);
    }
    
    public void Delete(int id)
    {
        Data.Database.Veterinaries.RemoveAll(v => v.VeterinarianId == id);
    }

    public void Update(Veterinarian veterinarian)
    {
        // 1. Encontrar el índice del veterinario a actualizar
        Data.Database.Veterinaries
            .FindIndex(v => v.VeterinarianId == veterinarian.VeterinarianId);
    }

    public Veterinarian GetById(int id)
    {
        return Data.Database.Veterinaries
            .FirstOrDefault(v => v.VeterinarianId == id);
    }
    
    public List<Veterinarian> GetAll()
    {
        return Data.Database.Veterinaries;
    }
}