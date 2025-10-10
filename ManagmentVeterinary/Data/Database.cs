using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Data;

public class Database
{
   // Database creation
   public static Dictionary<int, Client> Clients { get; } = new Dictionary<int, Client>();
   public static List<Pet> Pets { get; } = new List<Pet>();
   public static List<Consultation> Consultations { get; } = new List<Consultation>();
   public static List<Veterinarian> Veterinaries { get; } = new List<Veterinarian>();
   
   
   
   // Simple id counters
   public static int NextMascotaId = 1;
   public static int NextClientId = 1;
   public static int NextVeterinarianId = 1;
   public static int NextConsultaId = 1;
   
   
   // creating a list with schedules
   public static List<TimeSpan> AvailableHours{get; } = new()
   {
      new TimeSpan(8, 0, 0),
      new TimeSpan(9, 0, 0),
      new TimeSpan(10, 0, 0),
      new TimeSpan(11, 0, 0),
      new TimeSpan(14, 0, 0),
      new TimeSpan(15, 0, 0),
      new TimeSpan(16, 0, 0)
   };

   
}

