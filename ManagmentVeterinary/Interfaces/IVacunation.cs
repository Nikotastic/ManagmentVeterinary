namespace ManagmentVeterinary.Models;

public class IVacunation : VeterinaryService
{
    public string VacunationName { get; set; }

    public IVacunation(DateTime date, string vaccineName)
        : base("Vacunation", date)
    {
        VacunationName = vaccineName;
    }

    public override void Attend(Pet pet)
    {
        Console.WriteLine($"Vaccinated {pet.Name} with {VacunationName} on {Date.ToShortDateString()}");
    }
}