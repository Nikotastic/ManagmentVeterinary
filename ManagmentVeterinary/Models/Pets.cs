namespace ManagmentVeterinary.Models;

public class Pet
{
    internal readonly object Owner;

    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string? Symptom { get; set; }

    public Pet(string name, string species, int age, string? symptom)
    {
        Name = name;
        Species = species;
        Age = age;
        Symptom = symptom;
    }
}