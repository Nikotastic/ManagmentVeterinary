namespace ManagmentVeterinary.Models;

public class Patient
{
    // Propiedades
    private static int id = 1;
    public int PatientId { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Phone { get; set; }
    // Lista de mascotas para conectar con el paciente
    public List<Pet> Pets { get; set; }
    
    // Constructor
    public Patient( string? name, int age, string? phone)
    {
        PatientId = id++;
        Name = name;
        Age = age;
        Phone = phone;
        Pets = new List<Pet>(); // Inicializamos la lista de mascotas
    }
}


