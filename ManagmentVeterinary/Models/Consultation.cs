using ManagmentVeterinary.Interfaces;
namespace ManagmentVeterinary.Models;
    public class Consultation : IAttentive
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }
        public DateTime Date { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public double Cost { get; set; }
        
        public Consultation(int id, int petId, int veterinarianId, DateTime date, string symptoms, string diagnosis, string treatment, double cost)
        {
            Id = id;
            PetId = petId;
            VeterinarianId= veterinarianId;
            Date = date;
            Symptoms = symptoms;
            Diagnosis = diagnosis;
            Treatment = treatment;
            Cost = cost;
        }

        public void Attend()
        {
            Console.WriteLine($"Consulta {Id} atendida el {Date}"); 
        }

        public override string ToString()
        {
            return $"Id:{Id} PetId:{PetId} VetId:{VeterinarianId} Date:{Date} Symptoms: {Symptoms} Diagnosis: {Diagnosis} Treatment: {Treatment}, Cost: {Cost}";
        }

    }

