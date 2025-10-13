# 🐾 ManagmentVeterinary

## 🧾 Introduction
ManagmentVeterinary is a console application for comprehensive veterinary management. It allows you to manage clients, pets, and veterinary services, applying Object-Oriented Programming (OOP) principles and the Repository pattern. The system facilitates the relationship between clients and pets, cascade deletion, and management of services such as consultations and vaccinations.

## Getting Started

##  📁 Folder Structure

```

├── README.md
├── ManagmentVeterinary.sln
└── ManagmentVeterinary
    ├── Data
    │   └── Database.cs
    ├── Docs
    │   ├── ClassDiagram.png
    │   └── UseCaseDiagram.png
    ├── Interfaces
    │   ├── IAtendible.cs
    │   ├── IClientRepository.cs
    │   ├── IConsultationRepository.cs
    │   ├── INotification.cs
    │   ├── IPetRepository.cs
    │   ├── IRegistrable.cs
    │   └── IVeterinarianRepository.cs
    ├── Models
    │   ├── Animals.cs
    │   ├── Client.cs
    │   ├── Consultation.cs
    │   ├── Person.cs
    │   ├── Pets.cs
    │   ├── Vacunation.cs
    │   ├── Veterinarian.cs
    │   └── VeterinaryService.cs
    ├── Repositories
    │   ├── ClientRepository.cs
    │   ├── ConsutationRepository.cs
    │   ├── IRepository.cs
    │   ├── PetRepository.cs
    │   └── VeterinarianRepository.cs
    ├── Services
    │   ├── ClientService.cs
    │   ├── ConsultationConsultation.cs
    │   ├── PetService.cs
    │   └── VeterinarianService.cs
    ├── Utils
    │   ├── BreakBucle.cs
    │   ├── Linq.cs
    │   ├── MenuClient.cs
    │   ├── MenuConsultation.cs
    │   ├── MenuMain.cs
    │   ├── MenuPet.cs
    │   └── MenuVeterinarian.cs
    ├── ManagmentVeterinary.csproj
    └── Program.cs
 
```
## 📄 Diagramas UML (located in `/docs` folder)

### 1. Use Case Diagram
Shows the **main actors** and **functions of the system**.  
 `docs/UseCaseDiagram.png`

### 2. Class Diagram
Presents the structure of the system:
- Model classes
- Services
- Repositories
- Interfaces
- Relationships between layers.
 `docs/ClassDiagram.png`

### ✅ Requirements
- .NET 8.0 SDK or higher
- Rider, Visual Studio, or any C# compatible editor
- Windows operating system (recommended)

### ⚙️ Installation
1. Clone the repository or download the source code.
2. Open the `ManagmentVeterinary.sln` solution in your preferred IDE.
3. Restore NuGet packages if necessary.

### ▶️ Execution
Build and run the project from the terminal or IDE:

```cmd
cd ManagmentVeterinary
 dotnet build
 dotnet run
 or dotnet run --project ManagmentVeterinary/ManagmentVeterinary.csproj
```

### 💡 Usage Examples
🐶 Pet management and polymorphism:
```csharp
List<Animals> animals = new List<Animals> { new Pets("Dog"), new Pets("Cat") };
foreach (var animal in animals)
{
    Console.WriteLine(animal.EmitirSonido()); // Woof, Meow
}
```
🔄 Cascade deletion:
```csharp
clientService.DeleteClient(clientId); // Deletes the client and their associated pets
```
📋 Pet listing:
```csharp
foreach (var pet in petService.ListPets())
{
    string owner = pet.Client == null ? "No owner" : pet.Client.Name;
    Console.WriteLine($"{pet.Name} - {owner}");
}
```

## 👤 Author

Nikol Velasquez

