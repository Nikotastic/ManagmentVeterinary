using ManagmentVeterinary.Models;

namespace ManagmentVeterinary.Models;

public abstract class VeterinaryService
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }

    protected VeterinaryService(int id, string description, decimal cost)
    {
        Id = id;
        Description = description;
        Cost = cost;
        Date = DateTime.Now;
    }

    // Método abstracto que debe ser implementado por las subclases
    public abstract void Attend(Pet pet);
}
