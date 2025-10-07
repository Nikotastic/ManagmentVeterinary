namespace ManagmentVeterinary.Models;

public abstract class VeterinaryService
{
    public string ServiceName { get; set; }
    public DateTime Date { get; set; }

    public VeterinaryService(string serviceName, DateTime date)
    {
        ServiceName = serviceName;
        Date = date;
    }

    // Método abstracto → las clases hijas deben implementarlo
    public abstract void Attend(Pet pet);
}