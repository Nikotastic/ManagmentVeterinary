namespace ManagmentVeterinary.Models;

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get;  set; }
    public string Sexo { get; set; }

    public Animal(string name, int age, string species, string sexo)
    {
        Name = name;
        Age = age;
        Species = species;
        Sexo = sexo;
    }

    public abstract string IssueSound();
}