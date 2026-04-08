using _11_kompozycja.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _11_kompozycja.Services
{
    internal class StatisticsService
    {
        public void ShowSummary(List<Vehicle> vehicles)
        {
            Console.WriteLine("=== STATYSTYKI POJAZDÓW ===");
            Console.WriteLine($"Liczba pojazdów: {vehicles.Count}");

            int cars = 0;
            int motorcycles = 0;
            int bicycles = 0;
            int electricCars = 0;

            foreach (var v in vehicles)
            {
                if (v is ElectricCar)
                    electricCars++;
                else if (v is Car)
                    cars++;
                else if (v is Motorcycle)
                    motorcycles++;
                else if (v is Bicycle)
                    bicycles++;
            }

            Console.WriteLine($"Samochody: {cars}");
            Console.WriteLine($"Motocycle: {motorcycles}");
            Console.WriteLine($"Rowery: {bicycles}");
            Console.WriteLine($"Elektryczne auta: {electricCars}");
        }
    }
}
