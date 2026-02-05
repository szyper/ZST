using System.Diagnostics.CodeAnalysis;

namespace project_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę elementów tablicy: ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            // wprowadzenie danych
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Podaj liczbę [{i + 1}]: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // wyświetlenie tablicy
            Console.WriteLine();
            Console.Write("Elementy tablicy: ");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            // obliczenia
            int sum = 0;
            int min = numbers[0];
            int max = numbers[0];

            foreach (int number in numbers)
            {
                // sum = sum + number;
                sum += number;

                if (number < min)
                {
                    min = number;
                }

                if (number > max)
                {
                    max = number;
                }
            }

            double avg = (double)sum / numbers.Length;

            // wyniki
            Console.WriteLine($"Suma elementów: {sum}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maksimum: {max}");
            Console.WriteLine($"Średnia: {avg}");

            int evenCount = 0;
            int oddCount = 0;

            Console.Write("Liczby parzyste: ");
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.Write(number + " ");
                    evenCount++;
                }
            }

            Console.Write("\nLiczby nieparzyste: ");
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    Console.Write(number + " ");
                    oddCount++;
                }
            }
            Console.WriteLine();

            Console.WriteLine($"Liczba liczb parzystych: {evenCount}");
            Console.WriteLine($"Liczba liczb nieparzystych: {oddCount}");
        }
    }
}
