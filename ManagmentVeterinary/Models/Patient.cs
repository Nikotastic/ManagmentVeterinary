namespace ManagmentVeterinary.Models;

public class Patient
{
    private static int id = 0;
    public int PatientId { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Symptom { get; set; }
    public Patient( string? name, int age, string? symptom)
    {
        PatientId = id++;
        Name = name;
        Age = age;
        Symptom = symptom;
    }
}