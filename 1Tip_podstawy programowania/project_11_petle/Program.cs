using System.ComponentModel;
using System.Xml.Serialization;

namespace project_10_petle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int accountBalance = 1000; // początkowe saldo
            int correctPin = 1234; // aktualny poprawny PIN
            int loginAttempts = 0; //licznik nieudanych prób logowania
            bool accessGranted = false;

            Console.WriteLine("=== Witaj w bankomacie ===");

            // etap 1 - weryfikacja pinu (max 3 próby)
            do
            {
                Console.Write("Podaj 4-cyfrowy kod PIN: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int enteredPin) && enteredPin >= 1000 && enteredPin <= 9999)
                {
                    if (enteredPin == correctPin)
                    {
                        accessGranted = true;
                        Console.WriteLine("PIN poprawny! Witamy w bankomacie\n");
                        break;
                    }
                    else
                    {
                        loginAttempts++;
                        Console.WriteLine($"Błędny PIN! Pozostało prób: {3 - loginAttempts}");
                    }
                }
                else
                {
                    loginAttempts++;
                    Console.WriteLine($"PIN musi mieć dokładnie 4 cyfry! Pozostało prób: {3 - loginAttempts}");
                }

            }
            while (loginAttempts < 3);

            // jeśli za dużo błędów - blokada karty
            if (!accessGranted)
            {
                Console.WriteLine("\n Za dużo nieudanych prób. Karta zostałą zablokowana!");
                return;
            }

            // etap 2 - główne menu bankomatu
            int choice;
            do
            {
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("\n\n             MENU BANKOMATU             ");
                Console.WriteLine("1. Sprawdź saldo");
                Console.WriteLine("2. Wypłata gotówki");
                Console.WriteLine("3. Wpłata gotówki");
                Console.WriteLine("4. Zmień PIN");
                Console.WriteLine("5. Wyjście");
                Console.WriteLine(new string('=', 40));
                Console.Write("Wybierz opcję (1-5): ");

                choice = int.Parse(Console.ReadLine());
            }
            while (choice != 5);
        }
    }
}
