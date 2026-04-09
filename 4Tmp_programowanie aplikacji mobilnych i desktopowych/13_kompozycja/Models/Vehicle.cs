using System;
using System.Collections.Generic;
using System.Text;

namespace _10_kompozycja.Models
{
    internal class Vehicle
    {
        private string _brand;
        private int _year;
       
        public string Brand
        {
            get => _brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Marka nie może być pusta");
                _brand = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1886 || value > DateTime.Now.Year + 1)
                    throw new ArgumentException("Nieprawidłowy rok produkci");
                _year = value;
            }
        }

        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        public virtual void Start()
        {
            Console.WriteLine("Pojazd został uruchomiony");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Marka: {Brand}, rok: {Year}");
        }
    }
}
