# ManagmentVeterinary

## Introduction
ManagmentVeterinary is a console application for comprehensive veterinary management. It allows you to manage clients, pets, and veterinary services, applying Object-Oriented Programming (OOP) principles and the Repository pattern. The system facilitates the relationship between clients and pets, cascade deletion, and management of services such as consultations and vaccinations.

## Getting Started

### Requirements
- .NET 8.0 SDK or higher
- Rider, Visual Studio, or any C# compatible editor
- Windows operating system (recommended)

### Installation
1. Clone the repository or download the source code.
2. Open the `ManagmentVeterinary.sln` solution in your preferred IDE.
3. Restore NuGet packages if necessary.

### Execution
Build and run the project from the terminal or IDE:

```cmd
cd ManagmentVeterinary
 dotnet build
 dotnet run
 or dotnet run --project ManagmentVeterinary/ManagmentVeterinary.csproj
```

### Usage Examples
Pet management and polymorphism:
```csharp
List<Animals> animals = new List<Animals> { new Pets("Dog"), new Pets("Cat") };
foreach (var animal in animals)
{
    Console.WriteLine(animal.EmitirSonido()); // Woof, Meow
}
```
Cascade deletion:
```csharp
clientService.DeleteClient(clientId); // Deletes the client and their associated pets
```
Pet listing:
```csharp
foreach (var pet in petService.ListPets())
{
    string owner = pet.Client == null ? "No owner" : pet.Client.Name;
    Console.WriteLine($"{pet.Name} - {owner}");
}
```

## Author

Nikol Veasquez

