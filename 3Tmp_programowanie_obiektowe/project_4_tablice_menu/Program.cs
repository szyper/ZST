using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = null;
            bool exit = false;

            while (!exit) 
            {
                DisplayMenu();
                Console.Write("\nTwój wybór: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice) 
                {
                    case 1:
                        array = CreateArray();
                        break;
                    case 2:
                        if (array != null)
                        {
                            FillArrayRandomly(array);
                        }
                        else
                        {
                            Console.WriteLine("Najpierw utwórz tablice wybierając pierwszą opcję");
                        }
                        break;
                    case 7:
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                                break;
                            }

            }
        }

        private static void FillArrayRandomly(int[] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 101);
            }

            Console.WriteLine("Tablica została wypełniona losowymi wartościami");
        }

        private static int[] CreateArray()
        {
            Console.Write("Podaj rozmiar tablicy: ");
            int size = int.Parse(Console.ReadLine());
            return new int[size];
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Utwórz tablicę");
            Console.WriteLine("2. Losuj zawartość tablicy");
            Console.WriteLine("3. Dodaj wartości do tablicy");
            Console.WriteLine("4. Wyświetl tablicę");
            Console.WriteLine("5. Sortuj tablicę niemalejąco");
            Console.WriteLine("6. Sortuj tablice nierosnąco");
            Console.WriteLine("7. Wyjdź");
        }
    }
}
