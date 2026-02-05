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
            const int n = 1000;

            bool[] isPrime = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            Console.WriteLine($"Liczby pierwsze w przedziale [2..{n}]:\n");

            int counter = 0;

            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    Console.Write($"{i, 4}");
                    counter++;

                    if (counter % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }


            Console.WriteLine($"\n\n\nZnaleziono {counter} liczb pierwszych");
            Console.WriteLine("\nNacisnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
