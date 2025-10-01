using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_5_tablice_wielowymiarowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] ints = new int[2, 3];

            //Console.WriteLine(ints.GetLength(0)); //2
            //Console.WriteLine(ints.GetLength(1)); //3

            int count = 1;
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    ints[i,j] = count;
                    count++;
                }
            }

            for (int i = 0; i < ints.GetLength(0); i++)
            {
                //Console.WriteLine("wiersz " + (i  + 1) + ": ");
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    Console.Write($"ints[{i},{j}]={ints[i,j]}  ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("\n\n****************************\n\n");

            int[,,] cube = new int[2, 3, 4];
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        cube[i, j, k] = count;
                    }
                }
            }

            count = 1;
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        Console.WriteLine($"cube[{i},{j},{k}]={count}");
                        count++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.Clear();
            count = 1;
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                Console.WriteLine($"cube[{i}]");
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    Console.WriteLine($"\tcube[{i},{j}]");
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        Console.Write($"\t\tcube[{i},{j},{k}]={count}");
                        count++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
    }
}
