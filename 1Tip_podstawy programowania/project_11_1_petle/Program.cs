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
                Console.WriteLine("\n Za dużo nieudanych prób. Karta została zablokowana!");
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

                // 1. sprawdzenie salda
                if (choice == 1)
                {
                    Console.WriteLine($"\nTwoje aktualne saldo: {accountBalance} zł\n");
                }

                // 2. wypłata gotówki
                else if (choice == 2)
                {
                    Console.Write("\nPodaj kwotę do wpłaty (musi być wielokrotnością 50 zł: )");
                    int amount = int.Parse(Console.ReadLine());

                    if (amount <= 0)
                    {
                        Console.WriteLine("Kwota musi być większa od zera!\n");
                    }
                    else if (amount % 50 != 0)
                    {
                        Console.WriteLine("Można wpłacać tylko wielokrotności 50 zł\n");
                    }
                    else if (amount > accountBalance)
                    {
                        Console.WriteLine("Brak wystarczających środków na koncie!\n");
                    }
                    else
                    {
                        //accountBalance = accountBalance - amount;
                        accountBalance -= amount;
                        Console.WriteLine($"Wypłacono {amount} zł");
                        Console.WriteLine($"Pozostało na koncie: {accountBalance} zł\n");
                    }
                }

                // 3. wpłata gotówki
                else if (choice == 3)
                {
                    Console.Write("\nPodaj kwotę do wpłaty: ");
                    int amount = int.Parse(Console.ReadLine());

                    if (amount > 0)
                    {
                        accountBalance += amount;
                        Console.WriteLine($"Wpłacono {amount} zł");
                        Console.WriteLine($"Nowe saldo: {accountBalance} zł\n");
                    }
                    else
                    {
                        Console.WriteLine("kwota wpłaty musi być dodatnia!\n");
                    }
                }

                // 4. zmiana Pin-u
                else if (choice == 4)
                {
                    Console.Write("\nPodaj aktualny PIN: ");
                    int oldPin = int.Parse(Console.ReadLine());

                    if (oldPin != correctPin)
                    {
                        Console.WriteLine("Błędny aktualny PIN!\n");
                    }
                    else
                    {
                        Console.Write("Podaj nowy 4-cyfrowy PIN: ");
                        string newPin1 = Console.ReadLine();
                        Console.Write("Powtórz nowy PIN: ");
                        string newPin2 = Console.ReadLine();

                        if (newPin1 == newPin2 && newPin1.Length == 4 && int.TryParse(newPin1, out int parsed))
                        {
                            correctPin = parsed;
                            Console.WriteLine("PIN został pomyślnie zmieniony!\n");
                        }
                        else
                        {
                            Console.WriteLine("Błąd: PIN-y się różnią lub nie mają dokładnie 4 cyfr!\n");
                        }
                    }

                }

                // 5. Wyjście z bankomatu
                else if (choice == 5)
                {
                    Console.WriteLine("\nDziękujemy za skorzystanie z bankomatu. Do widzenia!\n");
                }

                // nieprawidłowy wybór
                else
                {
                    Console.WriteLine("\nNiepoprawna opcja. Wybierz liczbę od 1 do 5\n");
                }
            }
            while (choice != 5);
        }
    }
}