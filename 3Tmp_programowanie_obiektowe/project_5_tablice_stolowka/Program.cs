using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_5_tablice_stolowka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,,] menu = new string[5, 3, 2];
            int[,,] calories = new int[5, 3, 2];
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            string[] meals = { "Breakfast", "Lunch", "Snack" };

            for (int i = 0; i < menu.GetLength(0); i++)
            {
                Console.WriteLine($"Wprowadź dane dla {days[i]}");
                for (int j = 0; j < menu.GetLength(1); j++)
                {
                    Console.WriteLine($"{meals[j]}");
                    for (int k = 0; k < menu.GetLength(2); k++)
                    {
                        Console.Write($"\tNazwa dania {k + 1}: ");
                        menu[i, j, k] = Console.ReadLine();
                        Console.Write($"\tkalorie dla dania {k + 1}: ");
                        while (!int.TryParse(Console.ReadLine(), out calories[i, j, k]) || calories[i, j, k] < 0)
                        {
                            Console.Write("\tPodaj poprawną wartość kalorii: ");
                        }
                    }
                }
            }

            double weeklySum = 0;
            int weeklyDishCount = 0;

            for (int i = 0; i < menu.GetLength(0); i++)
            {
                Console.WriteLine($"\n{days[i]}:");
                double dailySum = 0;
                int dailyDishCount = 0;

                for (int j = 0; j < menu.GetLength(1); j++)
                {
                    Console.WriteLine($"\t{meals[j]}:");
                    for (int k = 0; k < menu.GetLength(2); k++)
                    {
                        Console.WriteLine($"\tDanie {k + 1}: {menu[i, j, k]} ({calories[i, j, k]} kcal)");
                        dailySum += calories[i, j, k];
                        dailyDishCount++;
                    }
                }

                double dailyAverage = dailySum / dailyDishCount;
                Console.WriteLine($"Średnia kalorii w {days[i]}: {dailyAverage:F2} kcal");
                weeklySum += dailySum;
                weeklyDishCount += dailyDishCount;
            }

            double weeklyAverage = weeklySum / weeklyDishCount;
            Console.WriteLine($"\nŚrednia kalorii w tygodniu: {weeklyAverage:F2} kcal");

            int maxCalories = calories[0, 0, 0];
            string maxDish = menu[0, 0, 0];
            string maxDay = days[0];
            string maxMeal = meals[0];

            for (int i = 0; i < menu.GetLength(0); i++) 
            {
                for (int j = 0; j < menu.GetLength(1); j++) 
                { 
                    for(int k = 0;k < menu.GetLength(2); k++)
                    {
                        if (calories[i, j, k] > maxCalories)
                        {
                            maxCalories = calories[i, j, k];
                            maxDish = menu[i, j, k];
                            maxDay = days[i];
                            maxMeal = meals[j];
                        }
                    }
                }
            }

            Console.WriteLine($"\nNajbardziej kaloryczne danie: {maxDish} {maxCalories} kcal w {maxDay}, {maxMeal}");
        }
    }
}
