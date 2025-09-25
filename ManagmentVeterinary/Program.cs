using ManagmentVeterinary.Models;


string option;

do
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine(@"1. Register patient
2. List patients
3. Search patient
4. Exit");
    option = Console.ReadLine()!;

    switch (option)
    {
        case "1":
            ; break;
            
    }
} while (option != "0");



