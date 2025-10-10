namespace ManagmentVeterinary.Models;

// Abstract class for animals
public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }
    public string Sexo { get; set; }

    // Constructor
    protected Animal(string name, int age, string species, string sexo)
    {
        Name = name;
        Age = age;
        Species = species;
        Sexo = sexo;
    }

    // Abstract method that must be implemented by subclasses
    public abstract string IssueSound();
}