using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_zdarzenia_delegaty_interfejsy
{
    public interface IRandomList
    {
        int Count { get; }

        void Display();

        List<int> DivisibleBy3Or5();

        List<int> Odd();
        List<int> Ascending();
        List<int> Descending();
        public event EmptyListHandler EmptyList;
    }

    delegate List<int> ListOperation(RandomList list);

    public delegate void EmptyListHandler();

    class RandomList : IRandomList
    {
        private int[,] array;

        public int Count
        {
            get { return array.Length; }
        }

        public RandomList(int rows, int cols, int min, int max)
        {
            array = new int[rows, cols];
            Random rnd = new Random();

            // wypełnienie listy losowymi liczbami
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rnd.Next(min, max + 1);
                }
            }

            if (array.Length == 0)
            {
                EmptyList?.Invoke();
            }
        }

        public void Display()
        {
            if (array.Length == 0)
            {
                EmptyList?.Invoke();
                return;
            }

            foreach (int x in list)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        public List<int> DivisibleBy3Or5()
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

        public List<int> Odd()
        {
            List<int> result = new List<int>();

            foreach (int x in list)
            {
                if (x % 2 != 0)
                {
                    result.Add(x);
                }
            }
            return result;
        }

        public List<int> Ascending()
        {
            List<int> result = new List<int>(list);

            result.Sort();

            return result;
        }

        public List<int> Descending()
        {
            List<int> result = new List<int>(list);

            result.Sort();
            result.Reverse();
            return result;
        }

        public event EmptyListHandler? EmptyList;
    }
    internal class Program
    {
        static void PerformOperation(IRandomList list, ListOperation operation, string message)
        {
            List<int> result = operation(list as RandomList);

            Console.WriteLine(message);

            foreach (int x in result)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        static void ShowMessage()
        {
            Console.WriteLine("Lista jest pusta!");
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Wyświetl listę liczb podzielnych przez 3 lub 5");
            Console.WriteLine("2. Wyświetl list liczb nieparzystych");
            Console.WriteLine("3. Wyświetl listę liczb posortowanych rosnąco");
            Console.WriteLine("4. Wyświetl listę liczb posortowanych malejąco");
            Console.WriteLine("5. Zakończ program");
        }
        static void Main(string[] args)
        {
            IRandomList randomList = new RandomList(20, 1, 100);

            randomList.EmptyList += ShowMessage;

            Console.WriteLine("Lista liczb losowych: ");

            randomList.Display();

            int choice = 0;

            do
            {
                ShowMenu();

                Console.Write("Podaj swój wybór: ");
                string? input = Console.ReadLine();

                if (input != null)
                {
                    bool success = int.TryParse(input, out choice);

                    if (success)
                    {
                        switch (choice)
                        {
                            case 1:
                                PerformOperation(randomList, list => list.DivisibleBy3Or5(), "Lista liczb podzielnych przez 3 lub 5");
                                break;
                            case 2:
                                PerformOperation(randomList, list => list.Odd(), "Lista liczb nieparzystych");
                                break;
                            case 3:
                                PerformOperation(randomList, list => list.Odd(), "Lista liczb posortowanych rosnąco");
                                break;
                            case 4:
                                PerformOperation(randomList, list => list.Descending(), "Lista liczb posortowanych malejąco");
                                break;
                            case 5:
                                Console.WriteLine("Koniec programu");
                                break;
                            default:
                                Console.WriteLine("Niepopawny wybór");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podaj ponownie swój wybór");
                    }
                }
                else
                {
                    Console.WriteLine("Dokonaj wyboru");
                }
            }
            while (choice != 5);
        }
    }
}
