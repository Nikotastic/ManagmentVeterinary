namespace ManagmentVeterinary.Menu;

public static class BreakBucle
{
    public static string? GetStringOrCancel(string message, bool allowEmpty = false)
    {
        while (true)
        {
            Console.Write($"{message} (or 'cancel' to exit): ");
            string input = Console.ReadLine()!.Trim();

            if (input.ToLower() == "cancel")
                return null;

            if (!allowEmpty && string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("This field cannot be empty.");
                continue;
            }

            return input; 
        }
    }
    // Utiliza un delegado genérico (Func<int, T?>) que permite pasarle al método la función de búsqueda del repositorio (_petRepository.GetById o _veterinarianRepository.GetById) como argumento
    public static int? GetValidId<T>(string entityName, Func<int, T?> repositoryLookup) where T : class
    {
        int id;
        string? input;

        while (true)
        {
            Console.Write($"Insert ID {entityName} (or 'cancel' to exit): ");
            input = Console.ReadLine()!.Trim();

            if (input.ToLower() == "cancel")
                return null; // Devuelve null si el usuario cancela

            if (!int.TryParse(input, out id))
            {
                Console.WriteLine("Invalid ID. Please enter a numeric value.");
                continue;
            }

            // Usa la función de búsqueda proporcionada (el delegado Func<int, T?>)
            var entity = repositoryLookup(id); 
            
            if (entity != null)
                return id; // Devuelve el ID si la entidad existe
            
            Console.WriteLine($"No {entityName.ToLower()} found with ID {id}. Try again.");
        }
    }
}