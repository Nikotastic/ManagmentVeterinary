using ManagmentVeterinary.Models;
using System.Collections.Generic;

namespace ManagmentVeterinary.Interfaces
{
    public interface IVeterinarianService
    {
        void AddVeterinarian(Veterinarian veterinarian);
        List<Veterinarian> GetVeterinarians();
    }
}
