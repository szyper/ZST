using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // deklaracja i inicjalizacja zmiennych różnych typów
            string fullName = "Anna Nowak";
            char firstLetterOfName = 'A';
            int age = 30;
            double heightMeters = 1.65;
            float bodyTemperature = 36.6f;
            decimal accountBalance = 2500.75m;
            bool isStudent = false;

            // wyświetlenie danych
            Console.WriteLine("Dane osobowe");
            Console.WriteLine($"Imię i nazwisko (string): {fullName}");
            Console.WriteLine($"Pierwsza litera imienia (char): {firstLetterOfName}");
            Console.WriteLine($"Wiek (int): {age} lat");
            Console.WriteLine($"Wzrost (double): {heightMeters}m");
            Console.WriteLine($"Temperatura ciała (float): {bodyTemperature} °C");
            Console.WriteLine($"Saldo konta (decimal): {accountBalance} PLN");
            Console.WriteLine($"Czy student? (bool): {isStudent}");

            // wykonywanie operacji na zmiennych
            Console.WriteLine("Wykonywanie operacji na zmiennych");
            int ageInTwoYears = age + 2;
            double heightInCm = heightMeters * 100;
            decimal deposit = 300.45m;
            decimal newBalance = accountBalance + deposit;
            bool hasHighTemperature = bodyTemperature >= 37.0f;
            char nextLetter = (char)(firstLetterOfName + 1); // następna litera w alfabecie

            // interakcja z użytkownikiem
            Console.Write("\nPodaj liczbę przepracowanych godzin w tym tygodniu: ");
            string hoursText = Console.ReadLine();
            if (int.TryParse(hoursText, out int hoursWorked))
            {
                decimal hourlyRate = 31.40m;
                decimal salary = hoursWorked * hourlyRate;
                Console.WriteLine($"Wynagrodzenie za {hoursWorked} godzin (decimal): {salary} PLN");
            }
            else
            {
                Console.WriteLine("Błąd: niepoprawny format liczby godzin");
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
