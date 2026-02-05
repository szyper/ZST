using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_12_1_tablice_wielowymiarowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tablica wielowymiarowa
            // tablica 2-wymiarowa (macierz) 3 wiersze x 4 kolumny
            int[,] macierz = new int[3, 4];

            // wypełnienie wartościami
            macierz[0, 0] = 10;
            macierz[0, 1] = 20;
            macierz[1, 2] = 777;
            macierz[2, 3] = -50;

            // sprawdzenie ilości elementów w wymiarze
            Console.WriteLine(macierz.GetLength(0)); // 3
            Console.WriteLine(macierz.GetLength(1)); // 4

            // wyświetlenie elementów tablicy
            // sposób 1
            Console.WriteLine("\n\nZawartość tablicy macierz:");
            for (int i = 0; i < macierz.GetLength(0); i++) // wiersze
            {
                for (int j = 0; j < macierz.GetLength(1); j++) // kolumny
                {
                    Console.Write($"{macierz[i,j], 6}"); // wyrównanie do 6 znaków
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n---\n");
            // sposób 2 - czytelny, z ramką i indeksami
            Console.WriteLine("         0   1   2   3");
            Console.WriteLine("  |--------------------|");
            
            for (int i = 0; i < macierz.GetLength(0); i++) // wiersze
            {
                Console.Write($"{i} |");
                for (int j = 0; j < macierz.GetLength(1); j++) // kolumny
                {
                    Console.Write($"{macierz[i, j],5}"); // wyrównanie do 5 znaków
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  |--------------------|");
        }
    }
}
