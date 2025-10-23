using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_6_listy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tworzenie listy liczb całkowitych
            List<int> list = new List<int>();

            // tworzenie obiektu generatora liczb losowych
            Random rand = new Random();

            // zakres od 1 do 100 (20 liczb)
            for (int i = 0; i < 20; i++)
            {
                list.Add(rand.Next(1, 101));
            }

            // wyświetlenie listy
            Console.WriteLine("Lista liczb losowych:");
            foreach (int x in list)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();

            List<int> divisible = DivisibleBy3Or5(list);

            // wyświetlenie listy
            Console.WriteLine("Lista liczb podzielnych przez 3 lub 5:");
            foreach (int x in divisible)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        private static List<int> DivisibleBy3Or5(List<int> list)
        {
            List<int> result = new List<int>();

            foreach (int x in list)
            {
                if (x % 3 == 0 || x % 5 == 0)
                {
                    result.Add(x);
                }
            }

            return result;
        }
    }
}
