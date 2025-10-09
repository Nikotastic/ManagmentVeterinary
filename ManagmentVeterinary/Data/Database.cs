using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Data;

public class Database
{
   public static Dictionary<int, Client> Clients { get; } = new Dictionary<int, Client>();
   public static List<Pet> Pets { get; } = new List<Pet>();
   public static List<Consultation> Consultations { get; } = new List<Consultation>();
   public static List<Veterinarian> Veterinaries { get; } = new List<Veterinarian>();
   
   
   
   // Simple id counters
   public static int NextMascotaId = 1;
   public static int NextClientId = 1;
   public static int NextVeterinarianId = 1;
   public static int NextConsultaId = 1;
   
}