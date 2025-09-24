using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Witaj w programie ZST ===\n");

            Console.Write("Podaj swoje imię: ");
            string firstName = Console.ReadLine();

            Console.Write("Podaj swoje nazwisko: ");
            string lastName = Console.ReadLine();

            Console.Write("Podaj swoje miasto: ");
            string city = Console.ReadLine();

            Console.Write("Podaj swój wiek: ");
            int age = int.Parse(Console.ReadLine());

            int birthYear = DateTime.Now.Year - age;

            Console.WriteLine("\n--- Twoje dane ---");
            Console.WriteLine($"Imię i nazwisko: {firstName} {lastName}");
            Console.WriteLine($"Miasto: {city}");
            Console.WriteLine($"Wiek: {age}");
            Console.WriteLine($"Rok urodzenia: {birthYear}");

            if (age >= 18)
            {
                Console.WriteLine("Jesteś pełnoletni");
            }
            else
            {
                Console.WriteLine("Jesteś dzieckiem");
            }

            int choice = 0;
            while (choice != 3)
            {
                //menu
                Console.WriteLine("\n-- Menu --");
                Console.WriteLine("1. Wyświetl powitanie");
                Console.WriteLine("2. Wyświetl pełne dane");
                Console.WriteLine("3. Zakończ");

                Console.Write("Wybierz opcję (1-3): ");
                //choice = int.Parse(Console.ReadLine());
                bool valid = int.TryParse(Console.ReadLine(), out choice);

                if (!valid) 
                {
                    Console.WriteLine("Błędny wybór, spróbuj ponownie!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"\nWitaj {firstName} z miasta {city}");
                        break;
                    case 2:
                        Console.WriteLine($"\n{firstName} {lastName}, {age} lat, mieszka w {city}, urodzony w {birthYear} roku.");
                        break;
                    case 3:
                        Console.WriteLine("\nKoniec programu.");
                        break;
                    default:
                        Console.WriteLine("\nNieprawidłowa opcja!");
                        break;
                }
            }
            
        
        }
    }
}