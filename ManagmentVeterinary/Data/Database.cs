using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Data;

public class Database
{
    private static Database _instance;
    public Dictionary<int, Patient> Patients { get; private set; }

    private Database()
    {
        Patients = new Dictionary<int, Patient>();
    }

    public static Database Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Database();
            }
            return _instance;
        }
    }
}