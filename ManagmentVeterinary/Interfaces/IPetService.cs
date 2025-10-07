using ManagmentVeterinary.Models;
using System.Collections.Generic;

namespace ManagmentVeterinary.Interfaces
{
    public interface IPetService
    {
        void AddPetToPatient(int patientId, Pet pet);
        bool RemovePetFromPatient(int patientId, string petName);
        bool UpdatePet(int patientId, string oldPetName, Pet updatedPet);
    }
}
