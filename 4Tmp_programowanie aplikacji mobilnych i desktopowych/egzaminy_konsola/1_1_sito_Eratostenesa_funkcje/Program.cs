using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int maxNumber = 100;

            bool[] isPrime = new bool[maxNumber + 1];

            InitializePrimeArray(isPrime, maxNumber);
            RunEratosthenesSieve(isPrime, maxNumber);
            DisplayPrimeNumbers(isPrime, maxNumber);

            Console.WriteLine("\nNacisnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
    
        }

        private static void DisplayPrimeNumbers(bool[] PrimeArray, int maxValue)
        {
            Console.WriteLine($"Liczby pierwsze w przedziale [2..{maxValue}]:\n");

            int counter = 0;

            for (int i = 2; i <= maxValue; i++)
            {
                if (PrimeArray[i])
                {
                    Console.Write($"{i,4}");
                    counter++;

                    if (counter % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }


            Console.WriteLine($"\n\n\nZnaleziono {counter} liczb pierwszych");
        }

        private static void RunEratosthenesSieve(bool[] PrimeArray, int maxValue)
        {
            for (int i = 2; i * i <= maxValue; i++)
            {
                if (PrimeArray[i])
                {
                    for (int multiple = i * i; multiple <= maxValue; multiple += i)
                    {
                        PrimeArray[multiple] = false;
                    }
                }
            }
        }

        /*************************************************************************
         nazwa funkcji: InitializePrimeArray
         parametry wejściowe: bool[] primeArray - tablica flag liczb pierwszych
                                     int maxValue - górna granica przedziału
         wartość zwracana: brak (modyfikacja tablicy przez referencję)
         informacje: 
         * 
         * 
         * ***********************************************************************/

        private static void InitializePrimeArray(bool[] primeArray, int maxValue)
        {
            for (int i = 2; i <= maxValue; i++)
            {
                primeArray[i] = true;
            }
        }
    }
}
