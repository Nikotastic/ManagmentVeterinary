namespace ManagmentVeterinary.Models;

public abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
    
    public Person(int id, string name, string phone, string? email)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
    }
    
    
}