namespace ManagmentVeterinary.Models;

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }
    public string Sexo { get; set; }

    protected Animal(string name, int age, string species, string sexo)
    {
        Name = name;
        Age = age;
        Species = species;
        Sexo = sexo;
    }

    // Método abstracto que debe ser implementado por las subclases
    public abstract string IssueSound();
}