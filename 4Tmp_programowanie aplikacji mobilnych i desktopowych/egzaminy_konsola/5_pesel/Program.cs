
using System.Diagnostics.CodeAnalysis;

namespace _4_pesel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sprawdzenie numeru PESEL ===");
            Console.Write("Podaj numer PESEL (11 cyfr): ");
            string pesel = Console.ReadLine();

            if (pesel.Length != 11 || !IsDigitsOnly(pesel))
            {
                Console.WriteLine("Błąd: PESEL musi zawierać dokładnie 11 cyfr!");
                return;
            }

            char gender = GetGender(pesel);

            Console.Write("Płeć: ");
            if (gender == 'K')
                Console.WriteLine("Kobieta");
            else
                Console.WriteLine("Mężczyzna");

            bool isValid = CheckPesel(pesel);

            if (isValid)
                Console.WriteLine("PESEL jest POPRAWNY (zgodna suma kontrolna)");
            else
                Console.WriteLine("PESEL jest NIEPOPRAWNY (błędna suma kontrolna)");
        }

        /*
         ********************************* 
         nazwa funkcji: CheckPesel
         opis funkcji: sprawdza poprawność numeru PESEL na podstawie sumy kontrolnej
         parametry: pesel - łańcuch znaków zawierający numer PESEL
         zwracany typ i opis: bool - zwraca true, gdy PESEL jest poprawny, w przeciwnym razie false
         autor: 12345678901
         *********************************        */
        private static bool CheckPesel(string pesel)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3};

            int S = 0;

            for (int i = 0; i < 10; i++)
            {
                int digit = int.Parse(pesel[i].ToString());
                S += digit * weights[i];
            }

            int M = S % 10;

            int R;

            if (M == 0)
                R = 0;
            else
                R = 10 - M;

            int controlDigit = int.Parse(pesel[10].ToString());

            return R == controlDigit; 
        }

        private static char GetGender(string pesel)
        {
            int digit = int.Parse(pesel[9].ToString());

            if (digit % 2 == 0)
                return 'K';
            else
                return 'M';
        }

        private static bool IsDigitsOnly(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
